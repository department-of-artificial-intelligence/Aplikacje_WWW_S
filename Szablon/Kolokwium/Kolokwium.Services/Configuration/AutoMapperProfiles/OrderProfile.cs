using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            // Kiedt obiekty sa takie same, piszemy puste
            CreateMap<OrderDto, OrderVm>();

            CreateMap<MealDto, MealVm>();
            CreateMap<Meal, MealDto>();

            CreateMap<CreateOrderVm, CreateOrderDto>();


            // Kiedy mapujemy recznie cos, wtedy piszemy Ignore
            CreateMap<CreateOrderDto, Order>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.TotalPrice, o => o.Ignore())
            .ForMember(d => d.DeliveryAddress, o => o.Ignore()) 
            .ForMember(d => d.Meals, o => o.Ignore()); 

            CreateMap<Order, OrderDto>()
            .ForMember(d => d.TotalPrice, o => o.MapFrom(s => s.Meals.Sum(m => m.Price)))
            .ForMember(d => d.DeliveryAddress, o => o.MapFrom
            (s => s.DeliveryAddress != null ? 
            s.DeliveryAddress.Country + 
            ", " + s.DeliveryAddress.City + 
            ", " + s.DeliveryAddress.Street + 
            " " + s.DeliveryAddress.BuildingNumber +
            (s.DeliveryAddress.ApartmentNumber.HasValue ? "/" 
            + s.DeliveryAddress.ApartmentNumber.Value : string.Empty) 
            + ", " 
            + s.DeliveryAddress.ZipCode : string.Empty))
            .ForMember(d => d.Meals, o => o.MapFrom(s => s.Meals.Select(t => t.Description).ToList()));
        }
    }
}