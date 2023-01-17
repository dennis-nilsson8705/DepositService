using Data.CommandDtos;
using Infrastructure;
using MediatR;

namespace Command.Command;

public class CreateDepositCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public int Amount { get; set; }

    public string? Currency { get; set; }

    public bool? IsCrypto { get; set; }
    
    public int UserKey { get; set; }
    public ApplicationDbContext DbContext { get; set; }

    public CreateDepositCommand(ApplicationDbContext dbContext, CreateDepositDto dto)
    {
        DbContext = dbContext;
        Id = dto.Id;
        Amount = dto.Amount;
        IsCrypto = dto.IsCrypto ?? false;
        Currency = dto.Currency ?? string.Empty;
        UserKey = dto.UserKey;
    }
}