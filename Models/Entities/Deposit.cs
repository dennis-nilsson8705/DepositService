namespace Data.Entities;

public class Deposit
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public string? Currency { get; set; }
    public bool? IsCrypto { get; set; }
    
    public int UserKey { get; set; }

    public Deposit(Guid id, int amount, string currency, int userKey, bool? isCrypto)
    {
        Id = id;
        Amount = amount;
        Currency = currency ?? string.Empty;
        IsCrypto = isCrypto ?? false;
        UserKey = userKey;
    }
}