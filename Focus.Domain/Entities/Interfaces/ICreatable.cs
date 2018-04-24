using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Entities.Interfaces
{
    interface ICreatable
    {
        string CreatedBy { get; set; }

        DateTime? CreatedTime { get; set; }
    }
}
