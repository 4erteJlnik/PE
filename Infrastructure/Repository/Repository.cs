using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PE.Infrastructure.DTO;

namespace PE.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : WEntitydto
    {
        protected DbContext DbContext { get; }
        protected DbSet<TEntity> Entity { get; }
        public Repository(DbContext context)
        {
            //Получено с помощью DI
            DbContext = context;
            Entity = DbContext.Set<TEntity>();
        }
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns>DbSet</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Entity;
        }
        public IEnumerable<TEntity> GetNumber(int number)
        {
            return Entity.Take<TEntity>(number);
        }
        /// <summary>
        /// Найти по id
        /// </summary>
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await Entity.FindAsync(id);
        }
        /// <summary>
        /// Добавить
        /// </summary>
        public async Task AddAsyncAndSave(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            await Entity.AddAsync(entity);
            SaveChangesAsync();
        }
        /// <summary>
        /// Изменить
        /// </summary>
        public async Task EditAsyncAndSave(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Entity.Update(entity).State = EntityState.Modified;
            SaveChangesAsync();
        }
        /// <summary>
        /// Удалить
        /// </summary>
        public async Task DeleteAsyncAndSave(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Entity.Remove(entity);
            SaveChangesAsync();
        }
        public async Task DeleteAsyncAndSave(Guid id)
        {
            var entity = Entity.Where<TEntity>(e => e.ID == id);
            if (entity == null)
                throw new Exception("Не найдено" + nameof(TEntity) + id.ToString());
            Entity.Remove(entity.First<TEntity>());
            SaveChangesAsync();
        }
        /// <summary>
        /// Сохранить
        /// </summary>
        public void SaveChangesAsync()
        {
            DbContext.SaveChangesAsync().Wait();
        }
    }
}
