using Focus.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Focus.Domain.Entities
{
    public class Role : EntityBase, ICreatable, IDeletable, IModifiable
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        public bool Enabled { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
