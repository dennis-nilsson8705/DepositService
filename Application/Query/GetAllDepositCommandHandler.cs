using Data.Entities;
using MediatR;

namespace Command.Query;

public class GetAllDepositCommandHandler : IRequestHandler<GetAllDepositCommand, List<Deposit>>
{
 
    public GetAllDepositCommandHandler(   )
    {
     }

    public async Task<List<Deposit>> Handle(GetAllDepositCommand command, CancellationToken token)
    {
        var allDeposits = new List<Deposit>();// await _dbContext.Deposit!.ToListAsync(cancellationToken: token);

        return allDeposits;
    }
}