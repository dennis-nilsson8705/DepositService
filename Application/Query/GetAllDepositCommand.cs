using Data.Entities;
using MediatR;

namespace Command.Query;

public class GetAllDepositCommand : IRequest<List<Deposit>>
{
    public GetAllDepositCommand( )
    {

    }
}