using Focus.Domain.Entities.Interfaces;
using Focus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities
{
    public class User : EntityBase, ICreatable, IDeletable, IModifiable
    {
        public string Account { get; set; }

        public string RealName { get; set; }

        public string IdCard { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public Gender? Gender { get; set; }

        public string Avatar { get; set; }

        public DateTime? Birthday { get; set; }

        public string Mobile { get; set; }

        public string CompanyId { get; set; }

        public string DepartmentId { get; set; }

        public string WorkgroupId { get; set; }

        public bool Enabled { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public string RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual Company Company { get; set; }
    }
}
