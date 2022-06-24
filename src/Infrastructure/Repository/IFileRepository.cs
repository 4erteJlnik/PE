using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web1.Infrastructure;
using Web1.Infrastructure.Repository;

namespace Web1.Infrastructure.Repository
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
