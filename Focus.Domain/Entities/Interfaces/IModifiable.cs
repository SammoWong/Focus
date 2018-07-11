using System;

namespace Focus.Domain.Entities.Interfaces
{
    interface IModifiable
    {
        string ModifiedBy { get; set; }

        DateTime? ModifiedTime { get; set; }
    }
}
