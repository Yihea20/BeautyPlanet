//using BeautyPlanet.Migrations;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class Colors
    {
        [Key]
        public int Id { get; set; }
    public string Name { get; set; }
        public ICollection<ProductCenterColorSize> Products { get; set; }
    }
}
