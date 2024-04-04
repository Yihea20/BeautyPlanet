using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class UserRegistDTO : UserLoginDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> RoleName { get; set; }
        public int CenterId { get; set; }

    }
    public class UserLoginDTO
    {

        public string Email { get; set; }
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}
