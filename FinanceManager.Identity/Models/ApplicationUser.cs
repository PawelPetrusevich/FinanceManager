using Microsoft.AspNetCore.Identity;

namespace FinanceManager.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string BudgetId { get; set; }
    }
}