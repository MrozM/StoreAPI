using AutoMapper;
using Infrastructure.Models;

namespace Core.Models;

public class StoreMappingProfile : Profile
{
    public StoreMappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(p => p.Name, c => c.MapFrom(t => t.Name))
            .ForMember(p => p.Description, c => c.MapFrom(t => t.Description))
            .ForMember(p => p.Quantity, c => c.MapFrom(t => t.Quantity))
            .ForMember(p => p.Price, c => c.MapFrom(t => t.Price));

        CreateMap<UpdateProductDto, Product>()
            .ForMember(p => p.Description, c => c.MapFrom(t => t.Description))
            .ForMember(p => p.Price, c => c.MapFrom(t => t.Price))
            .ForMember(p => p.Quantity, c => c.MapFrom(t => t.Quantity));

        CreateMap<CreateProductDto, Product>()
            .ForMember(p => p.Name, c => c.MapFrom(t => t.Name))
            .ForMember(p => p.Description, c => c.MapFrom(t => t.Description))
            .ForMember(p => p.Price, c => c.MapFrom(t => t.Price))
            .ForMember(p => p.Quantity, c => c.MapFrom(t => t.Quantity));

        CreateMap<RegisterUserDto, User>()
            .ForMember(d => d.Email, s => s.MapFrom(v => v.Email))
            .ForMember(d => d.Username, s => s.MapFrom(v => v.Username))
            .ForMember(d => d.RoleId, s => s.MapFrom(v => v.RoleId));
    }
}