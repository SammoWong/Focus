using Focus.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Focus.Repository.EntityFrameworkCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FocusDbContext _focusDbContext;

        public UnitOfWork(FocusDbContext focusDbContext)
        {
            _focusDbContext = focusDbContext;
        }

        public void Commit()
        {
            _focusDbContext.SaveChanges();
            _focusDbContext.Database.CommitTransaction();
        }

        public void Dispose()
        {
            throw new Exception();
        }

        public void Rollback()
        {
            _focusDbContext.Database.RollbackTransaction();
        }

        public void SaveChanges()
        {
            _focusDbContext.SaveChanges();
        }
    }
}
