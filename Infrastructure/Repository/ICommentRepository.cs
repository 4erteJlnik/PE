using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
{
    public interface ICommentRepository<TEntity> : IRepository<TEntity> where TEntity : Commentsdto
    {
        IEnumerable<TEntity> ByUser(Guid user);
        IEnumerable<TEntity> ByUser(Peopledto user);
    }
}
