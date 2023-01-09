using AutoMapper;
using Data.Entities;
using Data.QueryDtos;

namespace DepositService.Data.Profiles;

public class DepositProfile : Profile
{
    public DepositProfile()
    {
        CreateMap<GetAllDepositDto, Deposit>();
    }
}