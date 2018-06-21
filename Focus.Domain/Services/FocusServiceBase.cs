using Focus.Domain.Entities;
using Focus.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Focus.Domain.Services
{
    public class FocusServiceBase<T> where T : EntityBase
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected readonly IRepository<T> Repository;

        public FocusServiceBase(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = repository;
        }
    }
}
