using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class CenterDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Phone { get; set; }
        public string? WebSiteUrl { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; }
        public IList<string> WorkingTime { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public int? Rate { get; set; }
    }
    public class EditCenter
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Phone { get; set; }
        public string? WebSiteUrl { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        // public IList<string> WorkingTime { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public int? Rate { get; set; }
    }
    public class GetCenterDTO:CenterDTO {
        public int Id { get; set; }
        public string? WebSiteUrl { get; set; }
        //[ForeignKey(nameof(Admin))]
        //public int? AdminId { get; set; }
        //public Admin? Admin { get; set; }
        public int? Rate { get; set; }
        public string? ImageUrl { get; set; }
        public IList<string> GalleryImage { get; set; }
        //[ForeignKey(nameof(Galary))]
        //  public int? GalaryId { get; set; }
        // public Gallery? Galary { get; set; }
        //  [ForeignKey(nameof(Platform))]
        // public int? PlatformId { get; set; }
        //public Platform? Platform { get; set; }
        public bool Active { get; set; }
        public List<string> WorkingTime { get; set; } 
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public ICollection<GetSpecialistDTO> Specialists { get; set; }
        public ICollection<CategoryIdDTO> Categories { get; set; }
        //public ICollection<GetCenterPost> Posts { get; set; }
    }
    public class GetCenterGalleryDTO : CenterDTO
    {
        public int Id { get; set; }
        public string? WebSiteUrl { get; set; }
        //[ForeignKey(nameof(Admin))]
        //public int? AdminId { get; set; }
        //public Admin? Admin { get; set; }
        public int? Rate { get; set; }
        public string? ImageUrl { get; set; }
        public IList<string> GalleryImage { get; set; }
        //[ForeignKey(nameof(Galary))]
        //  public int? GalaryId { get; set; }
        // public Gallery? Galary { get; set; }
        //  [ForeignKey(nameof(Platform))]
        // public int? PlatformId { get; set; }
        //public Platform? Platform { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }

        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public ICollection<GetSpecialistDTO> Specialists { get; set; }
        public ICollection<CategoryIdDTO> Categories { get; set; }
    }
    public class GetCenterwithIdDTO:GetCenterDTO
    {
       public int  Id { get; set; }
    }
    public class CenterFile
    {

        public CenterDTO Centers { get; set; }
        public IFormFile Files { get; set; }
    }
    public class AppCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rate { get; set; }
        public string ImageUrl { get; set; }
    }
    public class ProductCenterPDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

    }
    public class CenterGallery
    {

        public int CenterId  { get; set; }
        public IList<IFormFile> Files { get; set; }
    }
}
