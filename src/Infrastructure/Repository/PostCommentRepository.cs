using System;
using Microsoft.EntityFrameworkCore;
using Web1.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Web1.Infrastructure.Repository
{
    public class PostCommentRepository : CommentRepository<PostCommentdto>, IPostCommentRepository
    {
        public PostCommentRepository(DbContext context) : base(context)
        {
        }
        /// <summary>
        /// Все комментарии к обьявлению
        /// </summary>
        /// <param name="post">id обьявления </param>
        /// <returns> IEnumerable</returns>
        public IEnumerable<PostCommentdto> ByPost(Guid post)
        {
            return Entity.Where<PostCommentdto>(e => e.PostId == post).AsEnumerable<PostCommentdto>();
        }
        public IEnumerable<PostCommentdto> ByPost(Postdto post)
        {
            return Entity.Where<PostCommentdto>(e => e.Post.Equals(post)).AsEnumerable<PostCommentdto>();
        }
    }

}