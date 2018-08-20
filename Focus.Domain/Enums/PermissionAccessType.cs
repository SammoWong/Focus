using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Domain.Enums
{
    public enum PermissionAccessType : byte
    {
        [Display(Name = "模块")]
        Module = 1,

        [Display(Name = "按钮")]
        Button = 2
    }
}
