using System.Linq;
using System.Security.Claims;
using FinanceManager.Application.Common.Interfaces;
using FinanceManager.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly ApplicationUser user;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            user = userManager.Users.Single(x => x.Id == userId);
        }

        public ApplicationUser User => user;
    }
}