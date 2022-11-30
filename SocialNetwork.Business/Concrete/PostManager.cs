using AutoMapper;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Helpers.Result.Abstract;
using SocialNetwork.Core.Helpers.Result.Concrete.ErrorResults;
using SocialNetwork.Core.Helpers.Result.Concrete.SuccessResults;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.Concrete;
using SocialNetwork.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.Entities.DTOs.PostDTO;

namespace SocialNetwork.Business.Concrete
{
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;
        private readonly IMapper _mapper;

        public PostManager(IPostDal postDal, IMapper mapper)
        {
            _postDal = postDal;
            _mapper = mapper;
        }

        public IResult CreatePost(PostCreateDTO postCreate, Guid userId)
        {
            try
            {
                var mapper = _mapper.Map<Post>(postCreate);
                mapper.UserId = userId;
                mapper.PublishDate= DateTime.Now;
                _postDal.Add(mapper);

                return new SuccessResult();

            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

    }
}
