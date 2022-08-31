using AutoMapper;
using Core.Models;

namespace Store.Dtos.Mapping_Profiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderDto, Order>()
            .ForMember(d => d.Items, s => s.MapFrom(v => v.Items))
            .ForMember(d => d.User, s => s.MapFrom(v => v.User));
    }
}