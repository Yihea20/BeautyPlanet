using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class Code
    {
        [Key]
        public int Id { get; set; }
        public int MyCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
