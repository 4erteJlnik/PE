using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
{
    public interface IPostRepository : IRepository<Postdto>
    {
        IEnumerable<Postdto> ByUser(Guid user);
        IEnumerable<Postdto> ByUser(Peopledto user);
    }
}
