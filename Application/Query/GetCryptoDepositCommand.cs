using Data.Entities;
using Infrastructure;
using MediatR;

namespace Command.Query;
 
public class GetCryptoDepositCommand : IRequest<List<Deposit>>
{
    public ApplicationDbContext DbContext { get; set; }
    
    public bool IsCrypto { get; set; }

    public GetCryptoDepositCommand(ApplicationDbContext dbContext, bool isCrypto)
    {
        DbContext = dbContext;
        IsCrypto = isCrypto;
    }
}