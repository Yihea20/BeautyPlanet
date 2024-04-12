using BeautyPlanet.Models;
using System.Text.Json.Serialization;

namespace BeautyPlanet.DTOs
{
    public class ServiceDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
       // public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public string Duration { get; set; }
        public int Price { get; set; }
        public int Rate { get; set; }
    }
    public class ServiceFile
    {
        
        public ServiceDTO Services { get; set; }
        public IFormFile Files { get; set; }
    } 
    public class GetServiceDTO:ServiceDTO
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        
        public ICollection<CenterDTO> Centers { get; set; }
      
       // public ICollection<GetSpecialistDTO> Specialists { get; set; }
        
    }
    public class GetServiceBesic:ServiceDTO
    {
        public string ImageURL { get; set; }
        public int Id { get; set; }
    }
    public class GetServiceWithIdDTO:GetServiceDTO
    {
        public int Id { get; set; }
    }
}
