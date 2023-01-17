using Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Command.Command;

public class CreateDepositCommandHandler : IRequestHandler<CreateDepositCommand, bool>
{
    public CreateDepositCommandHandler()
    {
    }

    public async Task<bool> Handle(CreateDepositCommand command, CancellationToken token)
    {
        var users =   command.DbContext.Users!.Where(user => user.Key == command.UserKey).ToListAsync();
        if (command.DbContext.Users == null  || users.Result.Count == 0)
        {
            return false;
        }

        var deposit = new Deposit(
            command.Id, command.Amount, command.Currency ?? string.Empty, command.UserKey, command.IsCrypto ?? false
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