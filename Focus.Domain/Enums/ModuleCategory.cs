using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Domain.Enums
{
    public enum ModuleCategory : byte
    {
        [Display(Name = "目录")]
        Male = 1,

        [Display(Name = "页面")]
        Female = 2,
    }
}
