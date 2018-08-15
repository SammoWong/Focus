using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Module
{
    public class DeleteModuleInputModel
    {
        [Display(Name = "编号"), Required(ErrorMessage = "{0}不能为空")]
        public string Id { get; set; }
    }
}
