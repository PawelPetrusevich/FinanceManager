using System;
using System.Threading;
using System.Threading.Tasks;
using FinanceManager.Common.DbModels;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Application.Common.Interfaces
{
    public interface IFinanceManagerContext
    {
        public DbSet<BudgetDbModel> Budgets { get; set; }

        public DbSet<AccountDbModel> Accounts { get; set; }

        public DbSet<TransactionDbModel> Transactions { get; set; }

        public DbSet<TransactionCategoryDbModel> TransactionCategories { get; set; }

        public DbSet<TransactionSubCategoryDbModel> TransactionSubCategories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}