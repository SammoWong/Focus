using System;
using System.Linq;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Domain.Enums;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model.Article;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    public class ArticleController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Articles")]
        public async Task<IActionResult> GetAllAsync()
        {
            var service = Ioc.Get<IArticleService>();
            var articles = await service.GetAllAsync();
            var result = articles.Select(a => new ArticleOutputModel
            {
                Id = a.Id,
                Category = a.Category,
                Title = a.Title,
                Content = a.Content,
                IsTop = a.IsTop,
                Enabled = a.Enabled,
                CreatedTime = a.CreatedTime.Value
            });
            return Ok(new StandardResult().Succeed(null, result));
        }

        [HttpPost]
        [Route("api/[controller]/AddOrUpdate")]
        public async Task<IActionResult> AddOrUpdateAsync([FromForm]AddOrUpdateInputModel model)
        {
            var service = Ioc.Get<IArticleService>();

            if (string.IsNullOrEmpty(model.Id))
            {
                var article = new Article
                {
                    Id = model.Id,
                    Category = model.Category,
                    Title = model.Title,
                    Content = model.Content,
                    IsTop = model.IsTop,
                    Enabled = model.Enabled
                };
                article.CreatedBy = CurrentUserId;
                article.CreatedTime = DateTime.Now;
                await service.AddAsync(article);
                return Ok(new StandardResult().Succeed("添加成功"));
            }
            else
            {
                var article = await service.GetByIdAsync(model.Id);
                if (article == null)
                    return BadRequest(new StandardResult().Fail(StandardCode.InternalError, "文章不存在"));

                article.Category = model.Category;
                article.Title = model.Title;
                article.Content = model.Content;
                article.IsTop = model.IsTop;
                article.Enabled = model.Enabled;
                article.ModifiedBy = CurrentUserId;
                article.ModifiedTime = DateTime.Now;
                await service.UpdateAsync(article);
                return Ok(new StandardResult().Succeed("修改成功"));
            }
        }

        [HttpPost]
        [Route("api/[controller]/Delete")]
        public async Task<IActionResult> DeleteAsync([FromForm]DeleteArticleInputModel model)
        {
            var service = Ioc.Get<IArticleService>();
            var article = await service.GetByIdAsync(model.Id);
            if (article == null)
                return BadRequest(new StandardResult().Fail(StandardCode.InternalError, "文章不存在"));

            await service.DeleteAsync(article);
            return Ok(new StandardResult().Succeed("删除成功"));
        }
    }
}