using SocialNetwork.Core.Helpers.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SocialNetwork.Entities.DTOs.PostDTO;

namespace SocialNetwork.Business.Abstract
{
    public interface IPostService
    {
        IResult CreatePost(PostCreateDTO postCreate, Guid userId);
        PostCreateDTO Add(PostCreateDTO postCreate, Guid userId);
    }
}
