using FinAdvisor.BuildingBlocks.Domain.Models;

namespace FinAdvisor.FinAccountModule.Domain.Account;

public class Wallet(string currency): Entity
{
    public string Currency { get; set; } = currency;
    public decimal Amount { get; set; } = 0m;

    public void AddMoney(decimal amount)
    {
        Amount += amount;
    }

    public void TryRemoveMoney(decimal amount)
    {
        if (Amount - amount < 0)
        {
            throw new ArgumentException();
        }

        Amount-=amount;
    }
}