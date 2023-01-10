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
            await command.DbContext.AddAsync(deposit, cancellationToken: token);
        }
        catch (Exception e)

        {
            {
                Console.WriteLine(e);
                throw;
            }
        }

        await command.DbContext.SaveChangesAsync(token);
        return true;
    }
}