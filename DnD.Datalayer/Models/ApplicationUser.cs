using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DnD.Datalayer.Models
{
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            //Voeg custom claims toe met name de naam en tijdzone van de user
            var claims = new List<Claim>();
            userIdentity.AddClaims(claims);
            return userIdentity;
        }
    }
}
