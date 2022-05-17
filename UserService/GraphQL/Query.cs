using HotChocolate.AspNetCore.Authorization;
using Models;
using System.Security.Claims;

namespace UserService.GraphQL
{
    public class Query
    {
        [Authorize]
        public IQueryable<Profile> GetProfilesbyToken([Service] foodieappContext context, ClaimsPrincipal claimsPrincipal)
        {
            var userName = claimsPrincipal.Identity.Name;
            var user = context.Users.Where(o => o.Username == userName).FirstOrDefault();
            if (user != null)
            {
                var profiles = context.Profiles.Where(o => o.UserId == user.Id);
                return profiles.AsQueryable();
            }
            return new List<Profile>().AsQueryable();
        }
    }
}
