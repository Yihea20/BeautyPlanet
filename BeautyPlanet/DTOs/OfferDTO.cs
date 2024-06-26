﻿using BeautyPlanet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyPlanet.DTOs
{
    public class OfferDTO
    {

        //public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ServiceCenterId { get; set; }
        
    }
    public class GetOfferDTO:OfferDTO
    {
        public GetServiceCenter ServiceCente { get; set; }
        public string ImageUrl { get; set; }
        public int Id { get; set; }
    }
    public class GetOffersIdDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
    public class OfferFile
    {
        public OfferDTO Offers { get; set; }
        public IFormFile Files { get; set; }
    }
}
