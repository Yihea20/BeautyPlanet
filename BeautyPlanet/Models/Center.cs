using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.Models
{
    public class Center
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string? WebSiteUrl { get; set; }
        [ForeignKey(nameof(Admin))]
        public string? AdminId { get; set; }
        public Admin? Admin { get; set; }
        public int? Rate { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey(nameof(Galary))]
        public int? GalaryId { get; set; }
        public Gallery? Galary { get; set; }
        public string? Description { get; set; }
        [ForeignKey(nameof(Platform))]
        public int? PlatformId { get; set; }
        public Platform? Platform { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }

    }
}
