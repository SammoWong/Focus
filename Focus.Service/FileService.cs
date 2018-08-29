using Focus.Domain.Entities;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service
{
    public class FileService : FocusServiceBase, IFileService
    {
        public async Task<File> GetByIdAsync(string id)
        {
            using(var db = NewDbContext())
            {
                return await db.Files.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task UploadAvatarAsync(File file, User user)
        {
            using (var db = NewDbContext())
            {
                using (var tran = await db.Database.BeginTransactionAsync())
                {
                    await db.Files.AddAsync(file);
                    db.Users.Update(user);
                    await db.SaveChangesAsync();
                    tran.Commit();
                }
            }
        }
    }
}
