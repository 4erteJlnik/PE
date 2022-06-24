using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web1.Infrastructure;
using Web1.Infrastructure.Repository;

namespace Web1.Infrastructure.Repository
{
    public class FileReposiry : IFileRepository
    {
        private DbContext DbContext { get; }
        private DbSet<Filedto> Entity { get; }
        public FileReposiry(DbContext context)
        {
            //Получено с помощью DI
            DbContext = context;
            Entity = DbContext.Set<Filedto>();
        }
        public async Task AddFile(Filedto file)
        {
            Entity.Add(file);
        }
        public async Task AddFileAndSave(Filedto file)
        {
            Entity.Add(file);
            DbContext.SaveChangesAsync().Wait();
        }
        public void SaveChanges()
        {
            DbContext.SaveChangesAsync().Wait();
        }
        public async Task<Filedto> GetAvatar(Peopledto people)
        {
            return Entity.First(x => x.ID == people.ID);
        }

        public async Task<Filedto> GetAvatar(Guid peopleid)
        {
            return GetFile(peopleid).Result;
        }

        public async Task<Filedto> GetFile(Guid fileid)
        {
            return Entity.First(x => x.ID == fileid);
        }

        public async Task<List<Filedto>> GetByPost(Postdto post)
        {
            return Entity.Where<Filedto>(x => x.postid == post.ID).ToList<Filedto>();
        }

        public async Task<List<Filedto>> GetByPost(Guid post)
        {
            return Entity.Where<Filedto>(x => x.postid == post).ToList<Filedto>();
        }
    }
}