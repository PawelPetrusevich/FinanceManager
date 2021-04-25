using System;

namespace FinanceManager.Application.Common.Enums
{
    [Flags]
    public enum TransactionType
    {
        Cunsumption = 1,
        Income = 2
    }
}