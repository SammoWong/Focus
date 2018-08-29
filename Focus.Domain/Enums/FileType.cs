using System.ComponentModel.DataAnnotations;

namespace Focus.Domain.Enums
{
    public enum FileType : byte
    {
        [Display(Name = "头像")]
        Avatar = 1,

        [Display(Name = "LOGO")]
        Logo = 2
    }
}
