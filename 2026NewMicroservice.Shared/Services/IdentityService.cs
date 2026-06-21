using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace _2026NewMicroservice.Shared.Services
{
    public class IdentityService(IHttpContextAccessor httpContextAccessor) : IIdentityService
    {
        public Guid GetUserId
        {
            get
            {

                if (!httpContextAccessor.HttpContext!.User!.Identity!.IsAuthenticated)
                    throw new UnauthorizedAccessException("User Not Auhnetication");

                return Guid.Parse(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value ?? string.Empty);

            }
        }

        public string GetUserName
        {

            get
            {
                if (!httpContextAccessor.HttpContext!.User!.Identity!.IsAuthenticated)
                    throw new UnauthorizedAccessException("User Not Auhnetication");

                return httpContextAccessor.HttpContext.User.Identity.Name ?? string.Empty;
            }
        }

        public List<string> Roles
        {
            get
            {
                if (!httpContextAccessor.HttpContext!.User!.Identity!.IsAuthenticated)
                    throw new UnauthorizedAccessException("User Not Auhnetication");

                return httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value).ToList();

            }
        }
    }
}
