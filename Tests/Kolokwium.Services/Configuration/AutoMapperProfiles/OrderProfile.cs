using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Order;
using Kolokwium.ViewModel.VM.Order;
using Kolokwium.Services.DTO.Meal;
using Kolokwium.ViewModel.VM.Meal;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {

            CreateMap<Meal,MealDto>();
            CreateMap<MealDto,MealVm>();
            CreateMap<OrderDto,OrderVm>();
            CreateMap<CreateOrderVm,CreateOrderDto>();
            
            CreateMap<Order,OrderDto>()
                .ForMember( d=> d.Meals, o=> o.MapFrom(s=>s.Meals.Select(t=>t.Description).ToList()))
                .ForMember(d=> d.TotalPrice,o=> o.MapFrom( m=>m.Meals.Sum(p=>p.Price)))
                .ForMember(d=>d.Country, o=>o.MapFrom(s=>s.DeliveryAddress.Country))
                .ForMember(d=>d.City, o=>o.MapFrom(s=>s.DeliveryAddress.City))
                .ForMember(d=>d.Street, o=>o.MapFrom(s=>s.DeliveryAddress.Street));

            CreateMap<CreateOrderDto,Order>()
                .ForMember(d=>d.Id, o=> o.Ignore())
                .ForMember(d=>d.DeliveryAddress, o=> o.Ignore())
                .ForMember(d=>d.Meals,o=> o.Ignore())
                .ForMember(d=>d.TotalPrice, o=> o.Ignore());

        }
    }
}