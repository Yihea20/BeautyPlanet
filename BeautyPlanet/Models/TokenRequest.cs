namespace BeautyPlanet.Models
{
    public class TokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string rand { get; set; }
        public string Id {  get; set; }
    }
}
