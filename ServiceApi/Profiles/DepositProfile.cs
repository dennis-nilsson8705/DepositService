using AutoMapper;
using Command.Command;
using Data.CommandDtos;

namespace DepositService.Data.Profiles;

public class DepositProfile : Profile
{
    public DepositProfile()
    {
        CreateMap<CreateDepositDto, CreateDepositCommand>();
    }
}