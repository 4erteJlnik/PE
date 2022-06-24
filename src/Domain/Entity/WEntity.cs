using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Domain
{
    public class WEntity
    {
        /// <summary>
        /// id
        /// </summary>
        /// <value>Id</value>
        public Guid ID { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        /// <value>Дата создания</value>
        public DateTime DateOfCreate { get; set; }
        /// <summary>
        /// Должно создаватся автоматически
        /// </summary>
        public WEntity()
        {
            ID = Guid.NewGuid();
            DateOfCreate = DateTime.Now;
        }
        public WEntity(Guid id,DateTime date) 
        {
            ID = id;
            DateOfCreate = date;
        }
    }
}