using BeautyPlanet.Models;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class UserRegistDTO : UserLoginDTO
    {
        public ICollection<string> RoleName { get; set; }
       // public int CenterId { get; set; }

    }
    public class EditUsetProfile
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }
 
        public string? Address { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }

    }
    public class UserProfile
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfileImageURL { get; set; }
       // public string? ImageURL { get; set; }
        public DateTime? Birthday { get; set; }
        public string? PhoneNumber { get; set; }
        public int? Like { get; set; }
        public bool Ban { get; set; }
        public string? Address { get; set; }
        public double? lat { get; set; }
        public double? lng { get; set; }
        public int? Point { get; set; }
        public int OrderCount { get; set; }
        public int FavoriteCount { get; set; }

    }
    public class EditSpecialistProfile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public int CenterId { get; set; }
        public int Rate { get; set; }
        public string Exparences { get; set; }
        public int CategoryId { get; set; }
    }
    public class location{
        public double lat { get; set; }
        public double lng { get; set; }
        public string? Address { get; set; }
    }
    public class photo
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
        
    }
    public class UserOrder
    {
        public ICollection<GetShoppingCartDTO>? ShoppingCarts { get; set; }
    }
    public class UserLoginDTO
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string? DeviceTokken { get; set; }
    }
    public class GetUserDTO:UserRegistDTO
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string PhoneNumber { get; set; }

        public string? Address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string? DeviceTokken { get; set; }

    }
    public class GetUserHome
    {
        public int Point { get; set; }
    }
    public class SpecialisRegistDTO : UserLoginDTO
    {
       
        public ICollection<string> RoleName { get; set; }
    }
    public class GetSpecialistAppointment
    {
        public ICollection<GetAppointment>? Appointments { get; set; }
    }
    public class GetSpecialistDTO
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public int Rate { get; set; }
        public string Exparences { get; set; }
        public string Email { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        //public string? ImageURL { get; set; }
        public string? ProfileImageURL { get; set; }
        public string? DeviceTokken { get; set; }
        public int Like { get; set; }
        public int PoastNumber { get; set; }
        public int AppointmentNumber { get; set; }
        public CenterDTO Center { get; set; }
        public CategoryIdDTO Category { get; set; }
        public ICollection<GetAppointment>? Appointments { get; set; }
        public ICollection< GetServiceBesic> Services { get; set; }
    }
    public class AppSpecialist
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
    }
    public class UserReviews
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string? ProfileImageURL { get; set; }
    }
    public class AdminLogIn
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public ICollection<string> RoleName { get; set; }
        public string Email { get; set; }

        public GetCenterDTO  Center { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class RegistAdmin
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public ICollection<string> RoleName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CenterId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
