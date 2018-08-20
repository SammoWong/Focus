using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Role
{
    public class AddRoleInputModel
    {
        [Display(Name = "角色名称"), Required(ErrorMessage = "{0}不能为空")]
        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }
    }
}
