using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Domain
{
    public class PostComment: Comments
    {
        /// <summary>
        /// Id объявления, к которому оставлен комментарий
        /// </summary>
        /// <value>Id объявления </value>
        public Guid PostId{get;set;}
        /// <summary>
        /// Все свойства
        /// </summary>
        /// <param name="userid">Id автора</param>
        /// <param name="description">Текст</param>
        public PostComment(Guid postid,Guid userid,String description) :base(userid,description)
        {
            PostId = postid;
        }
        public PostComment(Guid ID,Guid PostId,Guid UserId, string Description,DateTime DateOfCreate) : base(ID,DateOfCreate,UserId,Description)
        {
            this.PostId = PostId;
        }
    }
}
