using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class AppointmentDTO
    {

        
        public string? SpecialistId { get; set; }

        public int CenterId { get; set; }


        public int? ServiceId { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }

        public string? CostomServiceName { get; set; }
        public string? description { get; set; }
        //public string? ImageUrl { get; set; }
        //public int StatusId { get; set; }
        public DateTime StartTime { get; set; }

    }
    public class AppointmentFile
    {

        public AppointmentDTO AppointmentDTO { get; set; }
        public IFormFile? Files { get; set; }
    }
    public class AppId
    {
        
    }
   
        public class GetAppointment
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? CostomServiceName { get; set; }
        public string? description { get; set; }
        public string? ImageUrl { get; set; }
        public string Status { get; set; }
        public GetCenterwithIdDTO Center { get; set; }
        public AppSpecialist Specialist { get; set; }
        public CategoryIdDTO Category { get; set; }
        public GetServiceBesic Service { get; set; }
    }
    public class GetDashAppointment
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string? CostomServiceName { get; set; }
        public string? description { get; set; }
        public string? ImageUrl { get; set; }
        public string Status { get; set; }
        public GetCenterwithIdDTO Center { get; set; }
        public AppSpecialist Specialist { get; set; }
        public CategoryIdDTO Category { get; set; }
        public GetServiceBesic Service { get; set; }
        public GetUserDTO User { get; set; }
    }
    public class GetCart
    {
        public int Id { get; set; }
        public AppProduct AppProduct{get;set;}
        public int Count { get; set; }
    }
}
