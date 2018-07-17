using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Focus.Auth.Models
{
    public class LoginInputModel
    {
        [Display(Name = "账号"), Required(ErrorMessage = "{0}不能为空")]
        public string Account { get; set; }

        [Display(Name = "密码"), Required(ErrorMessage = "{0}不能为空")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = true;

        public string ReturnUrl { get; set; }
    }
}
