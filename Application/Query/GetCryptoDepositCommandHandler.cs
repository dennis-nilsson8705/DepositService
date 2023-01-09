using Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Command.Query;

public class GetCryptoDepositCommandHandler : IRequestHandler<GetCryptoDepositCommand, List<Deposit>>
{
    public GetCryptoDepositCommandHandler()
    {
    }

    public async Task<List<Deposit>> Handle(GetCryptoDepositCommand request, CancellationToken token)
    {
        var cryptoDeposits = await request.DbContext.Deposit!.Where(deposit => deposit.IsCrypto == request.IsCrypto)
            .ToListAsync(cancellationToken: token);

        return cryptoDeposits;
    }
}