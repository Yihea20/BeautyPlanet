using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BeautyPlanet.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Service> Services { get; set; }
    }
}
