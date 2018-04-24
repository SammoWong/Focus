using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities.Interfaces
{
    interface IDeletable
    {
        bool IsDeleted { get; set; }

        string DeletedBy { get; set; }

        DateTime? DeletedTime { get; set; }
    }
}
