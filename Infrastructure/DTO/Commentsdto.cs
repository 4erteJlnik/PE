using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.DTO
{
    /// <summary>
    /// Связь бд комментариев пользователя
    /// </summary>
    public class Commentsdto : WEntitydto
    {
        /// <summary>
        /// Автор
        /// </summary>
        /// <value>Пользователь</value>
        public Peopledto User { get; set; }
        /// <summary>
        /// Id пользователя для БД
        /// </summary>
        /// <value>Id пользователя в БД</value>
        public Guid UserId { get; set; }

        /// <summary>
        /// Текст комментария
        /// </summary>
        /// <value>Текст</value>
        public String Description { get; set; }
    }
}
