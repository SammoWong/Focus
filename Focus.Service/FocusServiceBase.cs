using Focus.Repository.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Service
{
    public abstract class FocusServiceBase
    {
        protected FocusDbContext NewDbContext() => new FocusDbContext();
    }
}
