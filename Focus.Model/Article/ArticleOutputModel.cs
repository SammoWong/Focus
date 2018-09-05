using Focus.Domain.Enums;
using Focus.Infrastructure.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Model.Article
{
    public class ArticleOutputModel
    {
        public string Id { get; set; }

        public ArticleCategory Category { get; set; }

        public string CategoryText => Category.GetDisplayName();

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsTop { get; set; }

        public bool Enabled { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
