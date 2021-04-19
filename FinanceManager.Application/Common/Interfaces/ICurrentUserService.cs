using System;
using FinanceManager.Identity.Models;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public ApplicationUser User { get; }
    }
}