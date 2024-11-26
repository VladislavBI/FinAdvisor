using FinAdvisor.BuildingBlocks.Domain.Models;

namespace FinAdvisor.FinAccountModule.Domain.Account;

public class FinAccount(Guid userId) : AggregateRoot
{
    private readonly List<Wallet> _wallets = [];

    public Guid UserId { get; set; } = userId;
    public IReadOnlyCollection<Wallet> Wallets => _wallets.AsReadOnly();

    public void AddWallet(string currency)
    {
        if (_wallets.Any(x => string.Equals(x.Currency, currency)))
        {
            throw new ArgumentException();
        }

        var newWallet = new Wallet(currency);
        _wallets.Add(newWallet);
    }

    public void AddMoney(string currency, decimal amount)
    {
        var walletForOperation = _wallets.FirstOrDefault(w => string.Equals(w.Currency, currency));
        if (walletForOperation is null)
        {
            throw new ArgumentException();
        }

        walletForOperation.AddMoney(amount);
    }

    public void TryRemoveMoney(string currency, decimal amount)
    {
        var walletForOperation = _wallets.FirstOrDefault(w => string.Equals(w.Currency, currency));
        if (walletForOperation is null)
        {
            throw new ArgumentException();
        }

        walletForOperation.TryRemoveMoney(amount);
    }
}