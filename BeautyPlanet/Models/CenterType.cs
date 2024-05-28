using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.Models
{
    public class CenterType
    {
        [Key]
        public int Id { get;set; }
        public string Name { get;set; }
    }
}
