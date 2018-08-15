using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.User
{
    public class DeleteUserInputModel
    {
        [Display(Name = "编号"), Required(ErrorMessage = "{0}不能为空")]
        public string Id { get; set; }
    }
}
