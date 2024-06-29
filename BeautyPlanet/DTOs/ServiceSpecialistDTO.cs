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
        public Service Servicee { get; set; }
        public Specialist Specialistt { get; set; }
    }
    public class GetSp
    {
        public GetSpecialistDTO Specialistt { get; set; }
    }
}
