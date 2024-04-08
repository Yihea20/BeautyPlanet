using BeautyPlanet.Models;
using System.Text.Json.Serialization;

namespace BeautyPlanet.DTOs
{
    public class ServiceDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public string Duration { get; set; }
        public int Price { get; set; }
    }
    public class GetServiceDTO:ServiceDTO
    {
        [JsonIgnore]
        public ICollection<Center> Centers { get; set; }
        [JsonIgnore]
        public ICollection<Specialist> Specialists { get; set; }
        
    }
    public class GetServiceWithIdDTO:GetServiceDTO
    {
        public int Id { get; set; }
    }
}
