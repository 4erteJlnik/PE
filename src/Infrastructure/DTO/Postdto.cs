using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Infrastructure
{
    public class Postdto : WEntitydto
    {
        /// <summary>
        /// Название обьявления
        /// </summary>
        /// <value>Название обьявления</value>
        public String Name { get; set; }
        /// <summary>
        /// Описание обьявления
        /// </summary>
        public String Description { get; set; }
        /// <summary>
        /// Создатель
        /// </summary>
        public Peopledto Creator { get; set; }
        /// <summary>
        /// Id автора в бд
        /// </summary>
        /// <value>Id автора в бд</value>
        public Guid CreatorId { get; set; }
        /// <summary>
        /// Категория товара
        /// </summary>
        public Categorydto Category;
        public Guid CategoryId { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// Город объявления
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Ссылка на картинку
        /// </summary>
        /// <summary>
        /// Для бд(Возможно стоит создать классы для бд отдельно)
        /// </summary>
        public IEnumerable<RatingDB> Ratingobj;
        /// <summary>
        /// Комментарии
        /// </summary>
        public IEnumerable<PostCommentdto> Comments { get; set; }
        public IEnumerable<Filedto> Files { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Postdto postdto &&
                   ID.Equals(postdto.ID);
        }
    }
}
