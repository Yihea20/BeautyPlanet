using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class ServiceCenterDTO
    {
       
        public int ServiceId { get; set; }
        public int CenterId { get; set; }
    }
    public class GetServiceCenter : ServiceCenterDTO
    {
        public int Id { get; set; }
        public GetServiceBesic Service{get;set;}
        public GetCenterDTO Center { get; set; }
    }
    public class GetSearch
    {
        public GetServiceDTO Service { get; set; }
        

    }
}
