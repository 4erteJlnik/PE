using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
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
