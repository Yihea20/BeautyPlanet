using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class AppointmentDTO
    {
         public int ServiceSpecialistId { get; set; }
        public string UserId { get; set; }
        //public int StatusId { get; set; }
        public DateTime DateTime { get; set; }

    }
    public class AppId
    {
        
    }
    public class GetAppointment
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public GetCenterwithIdDTO Center { get; set; }
        public AppSpecialist Specialist { get; set; }
        public CategoryIdDTO Category { get; set; }
        public GetServiceBesic Service { get; set; }
    }
    public class GetCart
    {
        public int Id { get; set; }
        public AppProduct AppProduct{get;set;}
        public int Count { get; set; }
    }
}
