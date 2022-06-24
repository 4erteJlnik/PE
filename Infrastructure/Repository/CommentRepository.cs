using Microsoft.EntityFrameworkCore;
using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
{
    public class CommentRepository<TEntity> : Repository<TEntity>, ICommentRepository<TEntity> where TEntity : Commentsdto
    {
        public CommentRepository(DbContext context) : base(context)
        {
        }
        /// <summary>
        /// Все комментарии пользоватиеля
        /// </summary>
        /// <param name="user">id пользователя </param>
        /// <returns> IEnumerable</returns>
        public IEnumerable<TEntity> ByUser(Guid user)
        {
            return Entity.Where<TEntity>(e => e.UserId == user).AsEnumerable<TEntity>();
        }
        /// <summary>
        /// Все комментарии пользоватиеля
        /// </summary>
        /// <param name="user">пользователь </param>
        /// <returns> IEnumerable</returns>
        public IEnumerable<TEntity> ByUser(Peopledto user)
        {
            return Entity.Where<TEntity>(e => e.User.Equals(user)).AsEnumerable<TEntity>();
        }
    }
}
