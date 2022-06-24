using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Domain
{
    /// <summary>
    /// Комментарии к пользователям(продавцам можно сделать отдельно)
    /// </summary>
    public class Comments: WEntity
    {
        /// <summary>
        /// Id автора(GUID)
        /// </summary>
        /// <value>Пользователь</value>
        public Guid UserId{get;set;}

        /// <summary>
        /// Текст комментария
        /// </summary>
        /// <value>Текст</value>
        public String Description{get;set;}
        /// <summary>
        /// Все свойства
        /// </summary>
        /// <param name="userid">Id автора</param>
        /// <param name="description">Текст</param>
        public Comments(Guid userid,String description)
        {
            UserId = userid;
            Description = description;
        }
        
        public Comments(Guid id,DateTime date,Guid userid,String description) : base(id,date)
        {
            UserId = userid;
            Description = description;
        }
    }
}
