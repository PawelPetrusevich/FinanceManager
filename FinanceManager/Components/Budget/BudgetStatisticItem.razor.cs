using FinanceManager.Application.Common.Models;
using Microsoft.AspNetCore.Components;

namespace FinanceManager.Components.Budget
{
    public partial class BudgetStatisticItem
    {
        [Parameter] public BudgetStatisticItemVM Item { get; set; } = new BudgetStatisticItemVM();

        bool isCollapsed = true;
        string CollapseCssClass => isCollapsed ? "collapse" : null;

        void ToogleTableRow()
        {
            isCollapsed = !isCollapsed;
        }
    }
}
