using AutoMapper;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Business.Constants;
using SocialNetwork.Core.Helpers.Result.Abstract;
using SocialNetwork.Core.Helpers.Result.Concrete.ErrorResults;
using SocialNetwork.Core.Helpers.Result.Concrete.SuccessResults;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.DTOs;
using static SocialNetwork.Entities.DTOs.PostDTO;
using static SocialNetwork.Entities.DTOs.UserDTO;

namespace SocialNetwork.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        public IDataResult<IEnumerable<ProfilePostListDTO>> GetProfilePosts(Guid userId)
        {
            try
            {
                var result = _userDal.GetUserProfilePosts(userId);
                return new SuccessDataResult<IEnumerable<ProfilePostListDTO>>(result);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<IEnumerable<ProfilePostListDTO>>(e.Message);
            }
        }

        public IDataResult<UserByEmailDTO> GetUserByEmail(string email)
        {
            try
            {
                var user = _userDal.Get(x => x.Email == email);
                if (user.Email != null)
                {
                    var model = _mapper.Map<UserByEmailDTO>(user);
                    return new SuccessDataResult<UserByEmailDTO>(model);
                }
                else
                {
                    return new ErrorDataResult<UserByEmailDTO>(Messages.UserNotFound);
                }
            }
            catch (Exception e)
            {
                return new ErrorDataResult<UserByEmailDTO>(e.Message);
            }
        }
    }
}