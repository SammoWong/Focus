using Focus.Domain.Entities.Interfaces;
using Focus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities
{
    public class Organization : EntityBase, ICreatable, IDeletable, IModifiable
    {
        public string ParentId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public OrganizationCategory Category { get; set; }

        public int? SortNumber { get; set; }

        public bool Enabled { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
