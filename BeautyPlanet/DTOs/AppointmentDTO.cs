using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class AppointmentDTO
    {
        
        public int Id { get; set; }
        public int ServiceSpecialistId { get; set; }
        public string UserId { get; set; }
        //public int StatusId { get; set; }
        public DateTime DateTime { get; set; }

    }
    public class GetAppointment
    {
        public AppCenter Center { get; set; }
        public AppSpecialist Specialist { get; set; }
        public AppCategory Category { get; set; }
        public AppService Service { get; set; }
    }
}
