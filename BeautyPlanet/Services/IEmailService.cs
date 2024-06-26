using BeautyPlanet.DTOs;

namespace BeautyPlanet.Services
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
