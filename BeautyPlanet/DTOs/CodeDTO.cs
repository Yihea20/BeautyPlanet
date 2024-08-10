namespace BeautyPlanet.DTOs
{
    public class CodeDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class GetCodeDTO
    {
        public int MyCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
