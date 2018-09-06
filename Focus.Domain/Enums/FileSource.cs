using System.ComponentModel.DataAnnotations;

namespace Focus.Domain.Enums
{
    public enum FileSource : byte
    {
        [Display(Name = "头像")]
        Avatar = 1,

        [Display(Name = "LOGO")]
        Article = 2
    }
}
