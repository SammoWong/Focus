using Focus.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace Focus.Domain.Entities
{
    public class Company : EntityBase, ICreatable, IDeletable, IModifiable
    {
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string Nature { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Creator { get; set; }

        public string Contact { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public bool IsDeleted { get; set; }

        public string DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Organization> Organizations { get; set; }

        public virtual ICollection<Position> Positions { get; set; }

        public virtual ICollection<Module> Modules { get; set; }

        public virtual ICollection<DictionaryType> DictionaryTypes { get; set; }
    }
}
