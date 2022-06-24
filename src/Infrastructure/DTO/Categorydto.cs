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
    public class Categorydto
    {
        public Guid ID;
        public string Name;
        public List<Postdto> Post;

    }
}
