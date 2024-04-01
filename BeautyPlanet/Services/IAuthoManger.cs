using BeautyPlanet.Models;

namespace BeautyPlanet.Services
{
    public interface IAuthoManger
    {
        Task<bool> ValidateUser(UserLoginDTO personDTO);
        Task<string> CreatToken();
        Task<string> CreateRefreshToken();
        Task<TokenRequest> VerifyRefreshToken(TokenRequest request);
    }
}
