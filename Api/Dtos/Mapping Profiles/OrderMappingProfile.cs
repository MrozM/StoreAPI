using AutoMapper;
using Core.Models;

namespace Store.Dtos.Mapping_Profiles;

public class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<OrderDto, Order>()
            .ForMember(d => d.Items, s => s.MapFrom(v => v.Items));
        CreateMap<OrderItemDto, OrderItem>()
            .ForMember(d => d.Quantity, s => s.MapFrom(v => v.Quantity))
            .ForMember(d => d.ProductId, s => s.MapFrom(v => v.ProductId));
    }
}