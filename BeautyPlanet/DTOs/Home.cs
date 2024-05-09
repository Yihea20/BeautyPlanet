namespace BeautyPlanet.DTOs
{
    public class Home
    {
        public GetUserHome User { get; set; }
        public IList<CategoryIdDTO> Categories { get; set; }
        public IList<GetCenterwithIdDTO> Centers { get; set; }
        public IList<OfferHome> Offers { get; set; }
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
        public IList <GetShoppingCategory> GetShoppingCategory { get; set; }
        public IList<HomeProduct> GetProduct { get; set; }
        public IList<HomeProduct> NewProduct { get; set; }
    }
}
