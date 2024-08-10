using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeautyPlanet.DTOs
{
    public class ServiceSpecialistDTO
    {
        public int ServiceId { get; set; }
        public string SpecialistId { get; set; }

    }
    public class GetServiceSpecialist:ServiceSpecialist
    {

        public int Id { get; set; }
        public Service Service { get; set; }
        public Specialist Specialist { get; set; }
    }
    public class GetSp
    {
        public GetSpecialistDTO Specialist { get; set; }
    }
    public class GetSpTime
    {
        public IList<DateTime>? Times { get; set; }
    }
}
