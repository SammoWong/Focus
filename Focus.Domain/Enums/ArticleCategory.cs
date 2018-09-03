using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Domain.Enums
{
    public enum ArticleCategory : byte
    {
        [Display(Name = "网站公告")]
        Notice = 1,

        [Display(Name = "新闻中心")]
        News = 2,

        [Display(Name = "培训资料")]
        Training = 3,
    }
}
