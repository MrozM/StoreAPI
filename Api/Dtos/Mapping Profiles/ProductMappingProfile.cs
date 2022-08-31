using AutoMapper;
using Core.Models;
using Infrastructure.Models;

namespace Store.Dtos.Mapping_Profiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
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

    }
}