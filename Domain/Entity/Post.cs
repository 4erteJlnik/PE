using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Entity
{
    public class Post : WEntity
    {
        /// <summary>
        /// Все параметры
        /// </summary>
        /// <param name="name"></param>
        /// <param name="creatorid"></param>
        /// <param name="description"></param>
        /// <param name="picture"></param>
        /// <param name="category"></param>
        /// <param name="city"></param>
        /// <param name="cost"></param>
        public Post(String name, Guid creatorid, String description = "", Guid categoryid = new Guid(), string city = "", int cost = 0)
        {
            Name = name;
            Description = description;
            CreatorId = creatorid;
            CategoryId = categoryid;
            City = city;
            Cost = cost;
            Comments = new List<PostComment>();
        }
        /// <summary>
        /// Лучше не использовать
        /// </summary>
        public Post() : this("NoName", Guid.NewGuid(), "")
        { }
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
        /// Категория объявления
        /// </summary>
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
        /// Создатель
        /// </summary>
        public Guid CreatorId { get; set; }
        /// <summary>
        /// Комментарии
        /// </summary>
        public ICollection<PostComment> Comments { get; set; }
    }
}
