using AutoMapper;
using BeautyPlanet.DTOs;
using BeautyPlanet.Migrations;

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
            CreateMap<Category, CategoryIdDTO>().ReverseMap();
            CreateMap<Offer, GetOffersIdDTO>().ReverseMap();
            CreateMap<Specialist, SpecialisRegistDTO>().ReverseMap();
            CreateMap<Gallery,GalleryDTO>().ReverseMap();
            CreateMap<Gallery, GetGallery>().ReverseMap();
            CreateMap<Image, ImageDTO>().ReverseMap();
            CreateMap<Image, CreateImage>().ReverseMap();
            CreateMap<Center, AppCenter>().ReverseMap();
            CreateMap<Center, ProductCenterPDTO>().ReverseMap();
            CreateMap<Category, AppCategory>().ReverseMap();
            CreateMap<Service, AppService>().ReverseMap();
            CreateMap<Specialist, AppSpecialist>().ReverseMap();
            CreateMap<ServiceSpecialist, ServiceSpecialistDTO>().ReverseMap();
            CreateMap<ServiceSpecialist, GetServiceSpecialist>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, GetProduct>().ReverseMap();
            CreateMap<Product, AppProduct>().ReverseMap();
            CreateMap<ProductCenter, ProductCenterDTO>().ReverseMap();
            CreateMap<ProductCenter, GetProductCenter>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartDTO>().ReverseMap();
            CreateMap<ShoppingCart, GetShoppingCart>().ReverseMap();
            CreateMap<ShoppingCategory, ShoppingCategoryDTO>().ReverseMap();
            CreateMap<ShoppingCategory, GetShoppingCategory>().ReverseMap();
            CreateMap<ShoppingCategory, GetShoppingCategoryDTO>().ReverseMap();
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Company, GetCompanyDTO>().ReverseMap();
            CreateMap<Company, GetProductCompanyDTO>().ReverseMap();
            CreateMap<GetSearch, GetServiceDTO>().ReverseMap();
            CreateMap<Sizes, SizeDTO>().ReverseMap();
            CreateMap<Colors, ColorDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
            CreateMap<Review, GetReviewDTO>().ReverseMap();
            CreateMap<ProductColor, GetProductColorDTO>().ReverseMap();
            CreateMap<ProductColor, ProductColorDTO>().ReverseMap();
            CreateMap<ProductSize, ProductSizeDTO>().ReverseMap();
            CreateMap<ProductSize, GetProductSizeDTO>().ReverseMap();
            CreateMap<User, UserReviews>().ReverseMap();
            CreateMap<ListImage, ListImageDTO>().ReverseMap();
        }
    }
}
