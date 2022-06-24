using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Web1.Infrastructure
{
    /// <summary>
    /// Комментарии к пользователям(продавцам можно сделать отдельно)
    /// </summary>
    public class Peoplelogin: IdentityUser<Guid>
    { //111
        public Peopledto orig{get;set;}
    }
}
