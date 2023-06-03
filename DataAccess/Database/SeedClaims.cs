using System.Collections.Generic;
using System.Security.Claims;

namespace DataAccess.Database
{
    public class SeedClaims
    {
        public static List<Claim> Claims = new List<Claim>()
        {
            new Claim("Statistika", "Statistika"),
            new Claim("Stends", "Stends"),
            new Claim("Spends", "Spends"),
            new Claim("Employee", "Employee"),
            new Claim("Users", "Users"),
            new Claim("Position", "Position"),
            new Claim("Intern", "Intern"),
        };
    }
}
