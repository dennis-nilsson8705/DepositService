using Data.Entities;
using Data.QueryDtos;
using Infrastructure;
using MediatR;

namespace Command.Query;

public class GetDepositByCurrencyCommand : IRequest<List<Deposit>>
{
    public ApplicationDbContext DbContext { get; set; }
    
    public string Currency { get; set; }

    public GetDepositByCurrencyCommand(ApplicationDbContext dbContext, string currency)
    {
        DbContext = dbContext;
        Currency = currency;
    }
}