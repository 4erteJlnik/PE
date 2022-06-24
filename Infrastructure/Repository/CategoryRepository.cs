using Microsoft.EntityFrameworkCore;
using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        protected DbContext DbContext { get; }
        protected DbSet<Categorydto> Entity { get; }
        public CategoryRepository(DbContext context)
        {
            //Получено с помощью DI
            DbContext = context;
            Entity = DbContext.Set<Categorydto>();
        }

        public List<Categorydto> GetAll()
        {
            return Entity.ToList<Categorydto>();
        }

        public async Task<Categorydto> GetByIdAsync(Guid id)
        {
            return Entity.First(x => x.ID == id);
        }

        public async Task<Categorydto> FindByName(string name)
        {
            return Entity.First(x => x.Name == name);
        }
        public async Task<List<Categorydto>> FindByNameList(string name)
        {
            return Entity.Where<Categorydto>(x => x.Name == name).ToList<Categorydto>();
        }

        public async Task AddAsyncAndSave(Categorydto entity)
        {
            await Entity.AddAsync(entity);
            DbContext.SaveChangesAsync();
        }

        public async Task EditAsyncAndSave(Categorydto entity)
        {
            Entity.Update(entity);
            DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsyncAndSave(Categorydto entity)
        {
            Entity.Remove(entity);
            DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsyncAndSave(Guid id)
        {
            Entity.Remove(Entity.Find(id));
            DbContext.SaveChangesAsync();
        }
    }
}
