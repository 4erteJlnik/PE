using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Web1.Infrastructure;

namespace Web1.Validation
{
    public interface IPasswordValidator<T> where T : Peoplelogin
    {

        Task<IdentityResult> ValidateAsync(UserManager<T> manager, T user, string password);
    }
}
