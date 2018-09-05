using Focus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Article
{
    public class AddOrUpdateInputModel
    {
        public string Id { get; set; }

        [Display(Name = "文章类别"), Required(ErrorMessage = "{0}不能为空")]
        public ArticleCategory Category { get; set; }

        [Display(Name = "文章标题"), Required(ErrorMessage = "{0}不能为空")]
        public string Title { get; set; }

        [Display(Name = "文章内容"), Required(ErrorMessage = "{0}不能为空")]
        public string Content { get; set; }

        public bool IsTop { get; set; }

        public bool Enabled { get; set; }
    }
}
