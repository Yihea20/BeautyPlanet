using BeautyPlanet.Models;

namespace BeautyPlanet.DTOs
{
    public class Home
    {
        public UserProfile User { get; set; }
        public List<string> Banner { get; set; }
        public IList<CategoryIdDTO> Categories { get; set; }
        public IList<GetCenterwithIdDTO> Centers { get; set; }
        public IList<OfferHome> Offers { get; set; }
        public IList<GetSpecialistDTO> Specialist { get; set; }
    }
    public class HomeSearch
    {
        public IList<GetCenterDTO> Centers { get; set; }
        public IList<GetSpecialistDTO> Specialist { get; set; }
        public IList<GetServiceDTO> Services { get; set; }
    }
    public class OfferHome
    {
        public GetOffersIdDTO Offer { get; set; }
        public GetServiceBesic Service { get; set; }
        public GetCenterwithIdDTO Center {get;set;}
    }
    public  class ShopHome
    {
        public List<string> Banner { get; set; }
        public IList <GetShoppingCategory> GetShoppingCategory { get; set; }
        public IList<GetProduct> GetProduct { get; set; }
        public IList<GetProduct> NewProduct { get; set; }
    }
    public class Filter
    {
        public IList<CategoryIdDTO> Categories { get; set; }
        public IList<Rate> Rates { get; set; }
        public IList<DistanceDTO> Distances { get; set; }
    }
    public class FilterApplay
    {
        public int? CategoryId { get; set; }
        public int? DistanceId { get; set; }
        public int? MinRateRange { get; set; }
        public int? MaxRateRange { get; set; } 
        public int? MinPraice { get; set; }
        public int? MaxPraice { get; set; }
    }

}


