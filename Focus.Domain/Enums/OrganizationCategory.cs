﻿using System.ComponentModel.DataAnnotations;

namespace Focus.Domain.Enums
{
    public enum OrganizationCategory : byte
    {
        [Display(Name = "部门")]
        Department = 1,

        [Display(Name = "工作组")]
        Workgroup = 2,
    }
}
