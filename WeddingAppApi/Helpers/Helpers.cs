using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingAppApi.Helpers
{
    public static class Helpers
    {
        public static string GetUserFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            string jti = jwtSecurityToken.Claims.First(claim => claim.Type == "sub").Value;
            return jti;
        }
    }
    
}