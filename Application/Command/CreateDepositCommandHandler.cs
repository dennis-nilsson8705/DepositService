using Data.Entities;
using MediatR;

namespace Command.Command;

public class CreateDepositCommandHandler : IRequestHandler<CreateDepositCommand, bool>
{
    public CreateDepositCommandHandler()
    {
    }

    public async Task<bool> Handle(CreateDepositCommand command, CancellationToken token)
    {
        var deposit = new Deposit(
            command.Id, command.Amount, command.Currency ?? string.Empty, command.IsCrypto ?? false
        );
        try
        {
            var allDeposits = await command.DbContext.AddAsync(deposit, cancellationToken: token);
            return true;
        }
        catch (Exception e)

        {
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}