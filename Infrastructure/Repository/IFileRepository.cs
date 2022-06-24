using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
{
    public interface IFileRepository
    {
        Task AddFile(Filedto file);
        Task<Filedto> GetFile(Guid fileid);
        Task<Filedto> GetAvatar(Peopledto people);
        Task<List<Filedto>> GetByPost(Postdto post);
        Task<Filedto> GetAvatar(Guid peopleid);
        Task<List<Filedto>> GetByPost(Guid post);
        void SaveChanges();

    }
}
