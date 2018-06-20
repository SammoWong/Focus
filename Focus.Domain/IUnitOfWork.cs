using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();

        void SaveChanges();
    }
}
