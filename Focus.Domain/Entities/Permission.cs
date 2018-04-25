using Focus.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities
{
    public class Permission : EntityBase, ICreatable, IDeletable, IModifiable
    {
        public short MasterType { get; set; }

        public string MasterId { get; set; }

        public short AccessType { get; set; }

        public string AccessId { get; set; }

        public int? SortNumber { get; set; }

        public bool Enabled { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }
    }
}
