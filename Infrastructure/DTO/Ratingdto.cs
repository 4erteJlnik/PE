using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.DTO
{
    public class Ratingdto
    {
        public Peopledto Sender;
        public Guid Senderid;
        public Peopledto Recipient;
        public Guid Recipientid;
    }
}
