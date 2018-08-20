using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Domain.Enums
{
    public enum PermissionMasterType : byte
    {
        [Display(Name = "角色")]
        Role = 1,

        [Display(Name = "用户")]
        User = 2
    }
}
