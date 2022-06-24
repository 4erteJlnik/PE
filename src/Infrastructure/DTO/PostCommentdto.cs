using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Infrastructure
{
    public class PostCommentdto: Commentsdto
    {
        /// <summary>
        /// Связанное объявление
        /// </summary>
        /// <value>Объявление</value>
        public Postdto Post{get;set;}
        /// <summary>
        /// Id объявления 
        /// </summary>
        /// <value>Id объявления в бд</value>
        public Guid PostId{get;set;}
    }
}
