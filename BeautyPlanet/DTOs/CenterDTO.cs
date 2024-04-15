﻿using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class CenterDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Description { get; set; }
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
        //[ForeignKey(nameof(Galary))]
      //  public int? GalaryId { get; set; }
       // public Gallery? Galary { get; set; }
      //  [ForeignKey(nameof(Platform))]
       // public int? PlatformId { get; set; }
        //public Platform? Platform { get; set; }
        public DateTime? OpenTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public ICollection<GetSpecialistDTO> Specialists { get; set; }
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
}
