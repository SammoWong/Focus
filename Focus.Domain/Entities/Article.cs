using Focus.Domain.Entities.Interfaces;
using Focus.Domain.Enums;
using System;

namespace Focus.Domain.Entities
{
    public class Article : EntityBase, ICreatable, IModifiable
    {
        public ArticleCategory Category { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsTop { get; set; }

        public bool Enabled { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }
    }
}
