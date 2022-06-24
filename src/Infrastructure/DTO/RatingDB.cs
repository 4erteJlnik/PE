using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Комментарии к пользователям(продавцам можно сделать отдельно)
    /// </summary>
    public class RatingDB
    {
        public Peopledto Sender;
        public Guid Senderid;
        public Peopledto Recipient;
        public Guid Recipientid;
    }
}
