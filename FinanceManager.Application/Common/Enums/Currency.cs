using System;

namespace FinanceManager.Application.Common.Enums
{
    [Flags]
    public enum Currency
    {
        BYN = 1,
        USD = 2,
        EURO = 4
    }
}