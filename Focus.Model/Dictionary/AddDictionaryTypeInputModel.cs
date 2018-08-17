using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Dictionary
{
    public class AddDictionaryTypeInputModel
    {
        [Display(Name = "ParentId"), Required(ErrorMessage = "{0}不能为空")]
        public string ParentId { get; set; }

        [Display(Name = "名称"), Required(ErrorMessage = "{0}不能为空")]
        public string Name { get; set; }

        public int SortNumber { get; set; }

        public bool Enabled { get; set; }

        public string Remark { get; set; }
    }
}
