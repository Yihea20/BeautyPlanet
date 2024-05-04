using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class UserRegistDTO : UserLoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Point { get; set; }
        public ICollection<string> RoleName { get; set; }
       // public int CenterId { get; set; }

    }
    public class UserLoginDTO
    {

        public string Email { get; set; }
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
    public class GetUserDTO:UserRegistDTO
    {
        public string Id { get; set; }
        
        
    }
    public class GetUserHome
    {
        public int Point { get; set; }
    }
    public class SpecialisRegistDTO : UserLoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CenterId { get; set; }
        public int Rate { get; set; }
        public string Exparences { get; set; }
       
        public ICollection<string> RoleName { get; set; }
        // public int CenterId { get; set; }

    }
    public class GetSpecialistDTO: SpecialisRegistDTO
    {

        public string Id { get; set; }
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
    }
}
