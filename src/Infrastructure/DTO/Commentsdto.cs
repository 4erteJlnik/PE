using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Комментарии к пользователям(продавцам можно сделать отдельно)
    /// </summary>
    public class Commentsdto: WEntitydto
    {
        /// <summary>
        /// автор
        /// </summary>
        /// <value>Пользователь</value>
        public Peopledto User {get;set;}
        /// <summary>
        /// Id пользователя для БД
        /// </summary>
        /// <value>Id пользователя в БД</value>
        public Guid UserId {get;set;}

        /// <summary>
        /// Текст комментария
        /// </summary>
        /// <value>Текст</value>
        public String Description{get;set;}
    }
}
