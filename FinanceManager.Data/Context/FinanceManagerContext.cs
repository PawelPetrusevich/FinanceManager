using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using FinanceManager.Common.DbModels;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Data.Context
{
    public class FinanceManagerContext : DbContext
    {
        public FinanceManagerContext(DbContextOptions<FinanceManagerContext> options) : base(options)
        {

        }

        public DbSet<BudgetDbModel> Budgets { get; set; }

        public DbSet<AccountDbModel> Accounts { get; set; }

        public DbSet<TransactionDbModel> Transactions { get; set; }

        public DbSet<TransactionCategoryDbModel> TransactionCategories { get; set; }

        public DbSet<TransactionSubCategoryDbModel> TransactionSubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}