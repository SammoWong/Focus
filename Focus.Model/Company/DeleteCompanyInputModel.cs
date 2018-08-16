using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Company
{
    public class DeleteCompanyInputModel
    {
        [Display(Name = "编号"), Required(ErrorMessage = "{0}不能为空")]
        public string Id { get; set; }
    }
}
