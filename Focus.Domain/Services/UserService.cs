using Focus.Domain.Entities;
using Focus.Domain.Repositories;
using Focus.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Domain.Services
{
    public class UserService : FocusServiceBase<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {
        }

        public async Task AddAsync(User user)
        {
            await Repository.AddAsync(user);
        }
    }
}
