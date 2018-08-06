using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.User
{
    public class UpdateUserInputModel
    {
        public string Id { get; set; }

        [Display(Name = "姓名"), Required(ErrorMessage = "{0}不能为空")]
        public string RealName { get; set; }

        [Display(Name = "身份证"), Required(ErrorMessage = "{0}不能为空")]
        public string IdCard { get; set; }

        public string Email { get; set; }

        public DateTime? Birthday { get; set; }

        public string Mobile { get; set; }

        public bool Enabled { get; set; }
    }
}
