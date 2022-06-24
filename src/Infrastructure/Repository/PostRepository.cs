using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web1.Infrastructure;

namespace Web1.Infrastructure.Repository
{
    public class PostRepository : Repository<Postdto>, IPostRepository
    {
        public PostRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Postdto> ByUser(Guid user)
        {
            return Entity.Where<Postdto>(p => p.CreatorId == user).AsEnumerable<Postdto>();
        }
        /// <summary>
        /// Все комментарии пользоватиеля
        /// </summary>
        /// <param name="user">пользователь </param>
        /// <returns> IEnumerable</returns>
        public IEnumerable<Postdto> ByUser(Peopledto user)
        {
            return Entity.Where<Postdto>(e => e.Creator.Equals(user)).AsEnumerable<Postdto>();
        }
    }
}
