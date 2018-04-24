using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities.Interfaces
{
    interface IModifiable
    {
        string ModifiedBy { get; set; }

        DateTime? ModifiedTime { get; set; }
    }
}
