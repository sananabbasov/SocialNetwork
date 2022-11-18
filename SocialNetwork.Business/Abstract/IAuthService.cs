using SocialNetwork.Core.Helpers.Result.Abstract;
using static SocialNetwork.Entities.DTOs.UserDTO;

namespace SocialNetwork.Business.Abstract
{
    public interface IAuthService
    {
        IResult Login(LoginDTO login);
        IResult Register(RegisterDTO register);
    }
}