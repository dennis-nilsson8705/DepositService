using Data.CommandDtos;
using Infrastructure;
using MediatR;

namespace Command.Command;

public class CreateUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public int Key { get; set; }
    public ApplicationDbContext DbContext { get; set; }

    public CreateUserCommand(ApplicationDbContext dbContext, CreateUserDto dto)
    {
        DbContext = dbContext;
        Id = dto.Id;
        Key = dto.Key;
        Name = dto.Name;
    }
}