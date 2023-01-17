using Data.Entities;
using MediatR;

namespace Command.Command;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
{
    public CreateUserCommandHandler()
    {
    }

    public async Task<bool> Handle(CreateUserCommand command, CancellationToken token)
    {
        var deposit = new Users(
            command.Id, command.Key, command.Name ?? string.Empty
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