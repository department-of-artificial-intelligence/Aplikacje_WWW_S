using AutoMapper;
using Kolokwium.Model.DataModels;
using Kolokwium.Services.DTO.Client;
using Kolokwium.Services.DTO.Order;
using Kolokwium.ViewModel.VM.Client;
using Kolokwium.ViewModel.VM.Order;

namespace Kolokwium.Services.Configuration.AutoMapperProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>()
            .ForMember(d => d.Orders, o => o.MapFrom(s => s.Orders.Select(t => t.Description).ToList()));
            CreateMap<ClientDto, ClientVm>();

            CreateMap<CreateClientVm, CreateClientDto>();
            CreateMap<CreateClientDto, Client>()
            .ForMember(d => d.Id, o => o.Ignore())
            .ForMember(d => d.Orders, o => o.Ignore());

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, OrderVm>();
        }
    }
}