using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Button
{
    public class AddButtonInputModel
    {
        [Display(Name = "名称"), Required(ErrorMessage = "{0}不能为空")]
        public string Name { get; set; }

        public string Code { get; set; }

        public string JsEvent { get; set; }

        public string Url { get; set; }

        public string Icon { get; set; }

        public int? SortNumber { get; set; }

        public string Remark { get; set; }

        [Display(Name = "模块"), Required(ErrorMessage = "{0}不能为空")]
        public string ModuleId { get; set; }

        public bool Enabled { get; set; }
    }
}
