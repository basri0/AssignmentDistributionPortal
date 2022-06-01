using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Core.Extensions.Concrete
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(type:ClaimTypes.Email,value: email));
        }

        public static void AddFullName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(type:ClaimTypes.Name,value: name));
        }

        public static void AddGivenName(this ICollection<Claim> claims, string givenName)
        {
            claims.Add(new Claim(type: ClaimTypes.GivenName, value: givenName));
        }

        public static void AddSurname(this ICollection<Claim> claims, string surname)
        {
            claims.Add(new Claim(type: ClaimTypes.Surname, value: surname));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(type:ClaimTypes.NameIdentifier, value: nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, List<string> roles)
        {
            roles.ForEach(role =>
          {
              claims.Add(new Claim(type: ClaimTypes.Role, value: role));
          });
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role =>
            {
                claims.Add(new Claim(type: ClaimTypes.Role, value: role));
            });
        }

    }
}
