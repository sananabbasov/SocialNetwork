using SocialNetwork.Business.Abstract;
using SocialNetwork.Business.Constants;
using SocialNetwork.Core.Helpers.Result.Abstract;
using SocialNetwork.Core.Helpers.Result.Concrete.ErrorResults;
using SocialNetwork.Core.Helpers.Result.Concrete.SuccessResults;
using SocialNetwork.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business.Concrete
{
    public class PostLikeManager : IPostLikeService
    {
        private readonly IPostLikeDal _postLikeDal;

        public PostLikeManager(IPostLikeDal postLikeDal)
        {
            _postLikeDal = postLikeDal;
        }

        public IResult LikePost(Guid userId, int postId)
        {
            try
            {
                _postLikeDal.LikePost(userId, postId);
                return new SuccessResult(Messages.SuccessfullyLike);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
