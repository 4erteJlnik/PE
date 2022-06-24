using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Получить все из бд
        /// </summary>
        /// <returns>IEnumerable</returns>
        IEnumerable<TEntity> GetAll();
        /// <summary>
        /// Получить несколько
        /// </summary>
        /// <param name="number">Число элементов</param>
        /// <returns>IEnumerable</returns>
        IEnumerable<TEntity> GetNumber(int number);
        /// <summary>
        /// Получить по id из бд
        /// </summary>
        /// <returns>object</returns>
        Task<TEntity> GetByIdAsync(Guid id);
        /// <summary>
        /// Добавить в бд(без сохранения)
        /// </summary>
        /// <returns></returns>
        Task AddAsyncAndSave(TEntity entity);
        /// <summary>
        /// изменить в бд(без сохранения
        /// </summary>
        /// <returns></returns>
        Task EditAsyncAndSave(TEntity entity);
        /// <summary>
        /// удалить в бд(без сохранения)
        /// </summary>
        /// <returns></returns>
        Task DeleteAsyncAndSave(TEntity entity);
        /// <summary>
        /// удалить в бд(без сохранения)
        /// </summary>
        /// <returns></returns>
        Task DeleteAsyncAndSave(Guid id);
        /// <summary>
        /// Сохранить в бд
        /// </summary>
        /// <returns></returns>
        void SaveChangesAsync();
    }
}
