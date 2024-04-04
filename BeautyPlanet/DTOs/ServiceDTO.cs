using BeautyPlanet.Models;

namespace BeautyPlanet.DTOs
{
    public class ServiceDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string ImageURL { get; set; }
        public string Category { get; set; }
        public string Duration { get; set; }
        public int Price { get; set; }
    }
    public class GetServiceDTO:ServiceDTO
    {
        
        public ICollection<Center> Centers { get; set; }
        public ICollection<Specialist> Specialists { get; set; }
        
    }
    public class GetServiceWithIdDTO:GetServiceDTO
    {
        public int Id { get; set; }
    }
}
