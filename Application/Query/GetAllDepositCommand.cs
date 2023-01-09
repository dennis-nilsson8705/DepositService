using Data.Entities;
using Infrastructure;
using MediatR;

namespace Command.Query;

public class GetAllDepositCommand : IRequest<List<Deposit>>
{
    public ApplicationDbContext DbContext { get; set; }

    public GetAllDepositCommand(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
}