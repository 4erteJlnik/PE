using Microsoft.EntityFrameworkCore;
using PE.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Repository
{
    public class PeopleRepository : Repository<Peopledto>, IPeopleRepository
    {
        private readonly DbContext RatingContext;
        private readonly DbSet<Ratingdto> ratingDBs;
        public PeopleRepository(DbContext context) : base(context)
        {
            RatingContext = context;
            ratingDBs = context.Set<Ratingdto>();
        }
        public int GetRating(Guid People)
        {
            return ratingDBs.Count<Ratingdto>(x => x.Recipientid == People);
        }
        public int GetRating(Peopledto People)
        {
            return ratingDBs.Count<Ratingdto>(x => x.Recipientid == People.ID);
        }
        public void AddRating(Peopledto Sender, Peopledto Recipient)
        {
            ratingDBs.Add(new Ratingdto
            {
                Senderid = Sender.ID,
                Recipientid = Recipient.ID
            });
        }
        public void AddRatingAndSave(Peopledto Sender, Peopledto Recipient)
        {
            ratingDBs.Add(new Ratingdto
            {
                Senderid = Sender.ID,
                Recipientid = Recipient.ID
            });
            RatingContext.SaveChangesAsync().Wait();
        }
        public void SaveChanges()
        {
            RatingContext.SaveChangesAsync().Wait();
        }
    }
}
