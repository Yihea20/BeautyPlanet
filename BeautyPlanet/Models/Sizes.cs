using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class Sizes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
