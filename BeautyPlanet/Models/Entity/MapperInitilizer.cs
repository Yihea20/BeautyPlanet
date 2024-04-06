using AutoMapper;
using BeautyPlanet.DTOs;

namespace BeautyPlanet.Models.Entity
{
    public class MapperInitilizer:Profile
    {
        public MapperInitilizer() {
            CreateMap<Center, CenterDTO>().ReverseMap();
            CreateMap<Center, GetCenterDTO>().ReverseMap();
            CreateMap<Center,GetCenterwithIdDTO>().ReverseMap();
            CreateMap<Service, GetServiceDTO>().ReverseMap();
            CreateMap<Service, ServiceDTO>().ReverseMap();
            CreateMap<Service,GetServiceWithIdDTO>().ReverseMap();
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserRegistDTO>().ReverseMap();
        }
    }
}
