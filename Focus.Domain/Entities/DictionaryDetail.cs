using Focus.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities
{
    public class DictionaryDetail : EntityBase, ICreatable, IDeletable, IModifiable
    {
        public string TypeId { get; set; }

        public string Name { get; set; }

        public int? SortNumber { get; set; }

        public string Remark { get; set; }

        public bool Enabled { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public virtual DictionaryType DictionaryType { get; set; }
    }
}
