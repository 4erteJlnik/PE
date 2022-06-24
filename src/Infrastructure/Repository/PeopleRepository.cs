using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web1.Infrastructure;

namespace Web1.Infrastructure.Repository
{
    public class PeopleRepository : Repository<Peopledto>, IPeopleRepository
    {
        private readonly DbContext RatingContext;
        private readonly DbSet<RatingDB> ratingDBs;
        public PeopleRepository(DbContext context) : base(context)
        {
            RatingContext = context;
            ratingDBs = context.Set<RatingDB>();
        }
        public int GetRating(Guid People)
        {
            return ratingDBs.Count<RatingDB>(x => x.Recipientid == People);
        }
        public int GetRating(Peopledto People)
        {
            return ratingDBs.Count<RatingDB>(x => x.Recipientid == People.ID);
        }
        public void AddRating(Peopledto Sender, Peopledto Recipient)
        {
            ratingDBs.Add(new RatingDB
            {
                Senderid = Sender.ID,
                Recipientid = Recipient.ID
            });
        }
        public void AddRatingAndSave(Peopledto Sender, Peopledto Recipient)
        {
            ratingDBs.Add(new RatingDB
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
