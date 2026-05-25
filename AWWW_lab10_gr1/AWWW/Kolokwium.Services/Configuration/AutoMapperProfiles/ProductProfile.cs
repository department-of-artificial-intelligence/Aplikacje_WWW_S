using System.Linq;
using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Product;
using Kolokwium.ViewModel.VM.Product;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            // VM -> DTO
            CreateMap<CreateProductVm, CreateProductDto>();
            CreateMap<ProductDto, ProductVm>();

            // Encja -> DTO
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.CategoryName,
                    o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.Tags,
                    o => o.MapFrom(s => s.Tags.Select(t => t.Name).ToList()));

            // DTO -> Encja
            CreateMap<CreateProductDto, Product>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Category, o => o.Ignore())
                .ForMember(d => d.Tags, o => o.Ignore());

            // Update DTO -> Encja
            CreateMap<UpdateProductDto, Product>()
                .ForMember(d => d.Category, o => o.Ignore())
                .ForMember(d => d.Tags, o => o.Ignore());
        }
    }
}