using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Domain
{
    public class People: WEntity
    {
        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public string FIO { set; get; } ///ФИО?

        /// <summary>
        /// Ссылка на аватар пользователя
        /// </summary>
        public string Avatar { set; get; }
        
        /// <summary>
        /// Рейтинг пользователя
        /// </summary>
        /// <value>Рейтинг</value>
        public short Rating { get; set; }//а почему бы и нет?
        /// <summary>
        /// Посты пользователя
        /// </summary>
        /// <value>Посты пользователя</value>
        public ICollection<Post> Posts {set;get;}
        /// <summary>
        /// Комментарии пользователя
        /// </summary>
        /// <value>Комментариии</value>
        public ICollection<Comments> Comments {set;get;}
        
    }
}
