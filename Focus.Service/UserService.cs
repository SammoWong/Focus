using Focus.Domain.Entities;
using Focus.Domain.Services;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class UserService : FocusServiceBase, IUserService
    {
        public async Task AddAsync(User user)
        {
            using(var db = base.NewDbContext())
            {
                await db.User.AddAsync(user);
                await db.SaveChangesAsync();
            }
        }
    }
}
