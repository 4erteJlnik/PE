using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.DTO
{
    /// <summary>
    /// Связь бд пользователей
    /// </summary>
    public class Peopledto : WEntitydto
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
        /// Посты пользователя
        /// </summary>
        /// <value>Посты пользователя</value>
        public ICollection<Postdto> Posts { set; get; }
        /// <summary>
        /// Рейтинг пользователя
        /// </summary>
        /// <value>Рейтинг</value>
        public short Rating { get; set; }//а почему бы и нет?
        public IEnumerable<Ratingdto> Ratingobj;
        /// <summary>
        /// Комментарии пользователя
        /// </summary>
        /// <value>Комментарии</value>
        public ICollection<PostCommentdto> Comments { set; get; }
        public ICollection<Filedto> Files { set; get; }

        public override bool Equals(object obj)
        {
            return obj is Peopledto peopledto &&
                   ID.Equals(peopledto.ID);
        }
        public Peoplelogindto Peoplelogin { get; set; }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
