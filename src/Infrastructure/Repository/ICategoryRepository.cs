using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Web1.Infrastructure.Repository
{


    public interface ICategoryRepository
    {
        /// <summary>
        /// Получить все из бд
        /// </summary>
        /// <returns>IEnumerable</returns>
        List<Categorydto> GetAll();
        /// <summary>
        /// Получить по id из бд
        /// </summary>
        /// <returns>object</returns>
        Task<Categorydto> GetByIdAsync(Guid id);
        /// <summary>
        /// Найти по названию
        /// </summary>
        /// <returns>object</returns>
        Task<Categorydto> FindByName(string name);
        /// <summary>
        /// Найти по названию
        /// </summary>
        /// <returns>object</returns>
        Task<List<Categorydto>> FindByNameList(string name);
        /// <summary>
        /// Добавить в бд(без сохранения)
        /// </summary>
        /// <returns></returns>
        Task AddAsyncAndSave(Categorydto entity);
        /// <summary>
        /// изменить в бд(без сохранения
        /// </summary>
        /// <returns></returns>
        Task EditAsyncAndSave(Categorydto entity);
        /// <summary>
        /// удалить в бд(без сохранения)
        /// </summary>
        /// <returns></returns>
        Task DeleteAsyncAndSave(Categorydto entity);
        /// <summary>
        /// удалить в бд(без сохранения)
        /// </summary>
        /// <returns></returns>
        Task DeleteAsyncAndSave(Guid id);
        /// <summary>
        /// Сохранить в бд
        /// </summary>
        /// <returns></returns>


    }
}