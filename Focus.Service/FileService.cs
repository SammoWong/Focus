using Focus.Domain.Entities;
using Focus.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

        public async Task UploadAsync(File file)
        {
            using(var db = NewDbContext())
            {
                await db.Files.AddAsync(file);
                await db.SaveChangesAsync();
            }
        }

        public string GenerateFileName(string extension, string fileId)
        {
            //var extension = System.IO.Path.GetExtension(originalFileName);
            return DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileId + extension;
        }

        public bool IsImage(string originalFileName)
        {
            string[] allowExtensions = { ".jpg", ".gif", ".png", ".bmp" };
            var fileExt = System.IO.Path.GetExtension(originalFileName).ToLower();
            return allowExtensions.Contains(fileExt);
        }
    }
}
