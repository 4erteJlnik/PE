using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web1.Infrastructure;
using Web1.Infrastructure.Repository;

namespace Web1.Infrastructure.Repository
{
    public interface IPostRepository : IRepository<Postdto>
    {
        IEnumerable<Postdto> ByUser(Guid user);
        IEnumerable<Postdto> ByUser(Peopledto user);
    }
}
