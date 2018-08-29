using Focus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Focus.Service.Interfaces
{
    public interface IFileService
    {
        Task UploadAvatarAsync(File file, User user);

        Task<File> GetByIdAsync(string id);
    }
}
