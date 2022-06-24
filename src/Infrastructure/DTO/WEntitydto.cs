using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Infrastructure
{
    public class WEntitydto
    {
        /// <summary>
        /// У всех сущностей есть id
        /// </summary>
        /// <value>Id обьекта</value>
        public Guid ID { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        /// <value>Дата создания</value>
        public DateTime DateOfCreate { get; set; }
        /// <summary>
        /// Рейтинг пользователя или комментария/"лайки" к обьявлению
        /// </summary>
        /// <value>Рейтинг</value>
    }
}