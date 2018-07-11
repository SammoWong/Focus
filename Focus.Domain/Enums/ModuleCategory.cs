using System.ComponentModel.DataAnnotations;

namespace Focus.Domain.Enums
{
    public enum ModuleCategory : byte
    {
        [Display(Name = "目录")]
        Catelog = 1,

        [Display(Name = "页面")]
        Page = 2,
    }
}
