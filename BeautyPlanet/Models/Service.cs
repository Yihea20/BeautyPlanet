using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Description { get; set; }
        public string Type { get; set; }
        public string? ImageURL { get; set; }
        public int Point { get; set; } = 0;
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category  Category{ get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<Center> Centers { get; set; }
        public ICollection<Specialist> Specialists { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
    }
}
