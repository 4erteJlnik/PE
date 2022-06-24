using System;
using Microsoft.EntityFrameworkCore;
using Web1.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Web1.Infrastructure.Repository
{


    public interface ICommentRepository<TEntity> : IRepository<TEntity> where TEntity : Commentsdto
    {
        IEnumerable<TEntity> ByUser(Guid user);
        IEnumerable<TEntity> ByUser(Peopledto user);
    }
}