using AutoMapper;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Entities.Concrete;
using SocialNetwork.Core.Helpers.Result.Abstract;
using SocialNetwork.Core.Helpers.Result.Concrete.ErrorResults;
using SocialNetwork.Core.Helpers.Result.Concrete.SuccessResults;
using SocialNetwork.Core.Security.Hashing;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.DTOs;
using static SocialNetwork.Entities.DTOs.UserDTO;

namespace SocialNetwork.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        public AuthManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public IResult Login(LoginDTO login)
        {
            try
            {
                return new SuccessResult("asdasda");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult Register(RegisterDTO register)
        {
            try
            {
                byte[] passwordHash,passwordSalt;
                var model = _mapper.Map<User>(register);
                HashingHelper.HashPassword(register.Password,out passwordHash,out passwordSalt);
                model.PasswordHash = passwordHash;
                model.PasswordSalt = passwordSalt;
                model.ProfilePicture = "/";
                _userDal.Add(model);
                return new SuccessResult("asdasda");
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}