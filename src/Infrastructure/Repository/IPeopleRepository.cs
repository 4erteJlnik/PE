using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web1.Infrastructure;
using Web1.Infrastructure.Repository;

namespace Web1.Infrastructure.Repository
{
    public interface IPeopleRepository : IRepository<Peopledto>
    {
        int GetRating(Guid People);
        int GetRating(Peopledto People);
        void AddRating(Peopledto Sender, Peopledto Recipient);
        void AddRatingAndSave(Peopledto Sender, Peopledto Recipient);
        void SaveChanges();
    }

}
