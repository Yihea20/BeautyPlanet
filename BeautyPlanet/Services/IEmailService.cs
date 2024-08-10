using BeautyPlanet.DTOs;

namespace BeautyPlanet.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailDTO request);
    }
}
