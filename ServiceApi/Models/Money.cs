namespace ApiProject.Models;

public class Money
{
    public Guid Id { get; set; }
    public int Amount { get; set; }
    public string? Currency { get; set; }
    
   // public bool IsCrypto { get; set; }
}