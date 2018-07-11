using System;

namespace Focus.Domain.Entities.Interfaces
{
    interface ICreatable
    {
        string CreatedBy { get; set; }

        DateTime? CreatedTime { get; set; }
    }
}
