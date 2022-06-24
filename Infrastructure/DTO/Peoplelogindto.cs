using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.DTO
{
    /// <summary>
    /// Связь бд и аунтитефикацией
    /// </summary>
    public class Peoplelogindto : IdentityUser<Guid>
    {
        public Peopledto Orig { get; set; }
    }
}
