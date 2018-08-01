using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Dictionary
{
    public class UpdateDictionaryDetailInputModel
    {
        [Display(Name = "Id"), Required(ErrorMessage = "{0}不能为空")]
        public string Id { get; set; }

        [Display(Name = "名称"), Required(ErrorMessage = "{0}不能为空")]
        public string Name { get; set; }

        public int SortNumber { get; set; }

        public bool Enabled { get; set; }

        public string Remark { get; set; }
    }
}
