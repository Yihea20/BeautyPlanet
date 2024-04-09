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
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryWithIdDTO>().ReverseMap();
            CreateMap<Specialist, UserRegistDTO>().ReverseMap();
            CreateMap<Specialist, UserLoginDTO>().ReverseMap();
            CreateMap<User, GetUserDTO>().ReverseMap();
            CreateMap<Specialist, GetSpecialistDTO>().ReverseMap();
            CreateMap<ServiceCenter, ServiceCenterDTO>().ReverseMap();
            CreateMap<ServiceCenter, GetServiceCenter>().ReverseMap();
            CreateMap<Offer, OfferDTO>().ReverseMap();
            CreateMap<Offer,GetOfferDTO>().ReverseMap();
            CreateMap<Service, GetServiceBesic>().ReverseMap();
            CreateMap<User, GetUserHome>().ReverseMap();
            CreateMap<ServiceCenter, GetSearch>().ReverseMap();
        }
    }
}
