using Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Command.Query;

public class GetDepositByCurrencyCommandHandler : IRequestHandler<GetDepositByCurrencyCommand, List<Deposit>>
{
    public GetDepositByCurrencyCommandHandler()
    {
    }

    public async Task<List<Deposit>> Handle(GetDepositByCurrencyCommand request, CancellationToken token)
    {
        var deposits = await request.DbContext.Deposit!.Where(deposit => deposit.Currency == request.Currency)
            .ToListAsync(cancellationToken: token);

        return deposits;
    }
}