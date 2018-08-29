using Focus.Domain.Entities.Interfaces;
using Focus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities
{
    public class File : EntityBase, ICreatable
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public FileType Type { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }
    }
}
