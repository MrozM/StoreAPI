using AutoMapper;
using Core.Models;

namespace Store.Dtos.Mapping_Profiles;

public class AccountMappingProfile : Profile
{
    public AccountMappingProfile()
    {
        CreateMap<RegisterUserDto, User>()
            .ForMember(d => d.Email, s => s.MapFrom(v => v.Email))
            .ForMember(d => d.Username, s => s.MapFrom(v => v.Username))
            .ForMember(d => d.RoleId, s => s.MapFrom(v => v.RoleId));

        CreateMap<LoginDto, User>()
            .ForMember(d => d.Email, s => s.MapFrom(v => v.Email));
    }
}