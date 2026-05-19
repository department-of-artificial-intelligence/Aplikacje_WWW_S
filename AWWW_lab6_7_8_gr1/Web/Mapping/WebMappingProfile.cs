using AutoMapper;
using Services.DTO.Room;
using Web.ViewModels.Room;

namespace Web.Mapping
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            // Mapowanie formularza prezentacji na obiekt żądania biznesowego
            CreateMap<CreateRoomViewModel, CreateRoomDto>();
        }
    }
}