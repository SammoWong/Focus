using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Domain.Enums
{
    public enum Gender : short
    {
        [Display(Name = "男性")]
        Male = 1,

        [Display(Name = "女性")]
        Female = 2,
    }
}
