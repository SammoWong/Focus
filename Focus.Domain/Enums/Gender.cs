using System.ComponentModel.DataAnnotations;

namespace Focus.Domain.Enums
{
    public enum Gender : byte
    {
        [Display(Name = "男性")]
        Male = 1,

        [Display(Name = "女性")]
        Female = 2,
    }
}
