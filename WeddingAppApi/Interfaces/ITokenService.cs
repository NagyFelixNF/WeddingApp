using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingAppApi.Models;

namespace WeddingAppApi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}