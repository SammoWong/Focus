using Focus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Module
{
    public class AddModuleInputModel
    {
        public string ParentId { get; set; }

        [Display(Name = "名称"), Required(ErrorMessage = "{0}不能为空")]
        public string Name { get; set; }

        public string Code { get; set; }

        public ModuleCategory Category { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public short Rank { get; set; }

        public int? SortNumber { get; set; }

        public bool IsExpanded { get; set; }

        public bool Enabled { get; set; }

        public string Remark { get; set; }
    }
}
