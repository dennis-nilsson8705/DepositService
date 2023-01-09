using Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Command.Query;

public class GetAllDepositCommandHandler : IRequestHandler<GetAllDepositCommand, List<Deposit>>
{
    public GetAllDepositCommandHandler()
    {
    }

    public async Task<List<Deposit>> Handle(GetAllDepositCommand command, CancellationToken token)
    {
        var allDeposits = await command.DbContext.Deposit!.ToListAsync(cancellationToken: token);

        return allDeposits;
    }
}