namespace BeautyPlanet.DTOs
{
    public class Home
    {
        public GetUserHome User { get; set; }
        public IList<CategoryIdDTO> Categories { get; set; }
        public IList<GetCenterwithIdDTO> Centers { get; set; }
        public IList<GetOffersIdDTO> Offers { get; set; }
    }
    public class HomeSearch
    {
        public IList<GetCenterDTO> Centers { get; set; }
        public IList<GetSpecialistDTO> Specialist { get; set; }
        public IList<GetSearch> Services { get; set; }
    }
}
