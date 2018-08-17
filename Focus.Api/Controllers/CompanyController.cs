using System;
using System.Threading.Tasks;
using Focus.Domain.Entities;
using Focus.Infrastructure;
using Focus.Infrastructure.Web.Common;
using Focus.Model.Company;
using Focus.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Focus.Api.Controllers
{
    [ApiController]
    public class CompanyController : FocusApiControllerBase
    {
        [HttpGet]
        [Route("api/Companies")]
        public async Task<IActionResult> GetAsync()
        {
            var service = Ioc.Get<ICompanyService>();
            var companies = await service.GetCompaniesAsync();
            return Ok(new StandardResult().Succeed(null, companies));
        }

        [HttpPost]
        [Route("api/Company/Delete")]
        public async Task<IActionResult> DeleteAsync([FromForm]DeleteCompanyInputModel model)
        {
            var service = Ioc.Get<ICompanyService>();
            var company = await service.GetByIdAsync(model.Id);
            if (company == null)
                return Ok(new StandardResult().Fail(StandardCode.ArgumentError, "公司不存在"));

            company.DeletedBy = CurrentUserId;
            company.DeletedTime = DateTime.Now;
            company.IsDeleted = true;
            await service.UpdateAsync(company);
            return Ok(new StandardResult().Succeed("删除成功"));
        }

        [HttpPost]
        [Route("api/Company/Add")]
        public async Task<IActionResult> AddAsync([FromForm]AddCompanyInputModel model)
        {
            var service = Ioc.Get<ICompanyService>();
            var company = new Company
            {
                Id = Guid.NewGuid().ToString(),
                FullName = model.FullName,
                ShortName = model.ShortName,
                Nature = model.Nature,
                Website = model.Website,
                Email = model.Email,
                Creator = model.Creator,
                Contact = model.Contact,
                Mobile = model.Mobile,
                Phone = model.Phone,
                Address = model.Address,
                Description = model.Description,
                CreatedBy = CurrentUserId,
                CreatedTime = DateTime.Now,
                Enabled = model.Enabled
            };
            await service.AddAsync(company);
            return Ok(new StandardResult().Succeed("添加成功"));
        }

        [HttpPost]
        [Route("api/Company/Update")]
        public async Task<IActionResult> UpdateAsync([FromForm]UpdateCompanyInputModel model)
        {
            var service = Ioc.Get<ICompanyService>();
            var company = await service.GetByIdAsync(model.Id);
            if (company == null)
                return Ok(new StandardResult().Fail(StandardCode.LogicError, "公司不存在"));

            company.FullName = model.FullName;
            company.ShortName = model.ShortName;
            company.Nature = model.Nature;
            company.Website = model.Website;
            company.Email = model.Email;
            company.Creator = model.Creator;
            company.Contact = model.Contact;
            company.Mobile = model.Mobile;
            company.Phone = model.Phone;
            company.Address = model.Address;
            company.Description = model.Description;
            company.Enabled = model.Enabled;
            await service.UpdateAsync(company);
            return Ok(new StandardResult().Succeed("修改成功"));
        }
    }
}