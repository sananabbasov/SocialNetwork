using SocialNetwork.Core.DataAccess.EntityFramework;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess.Concrete.EntityFramework
{
    public class PostLikeDal : EfRepositoryBase<PostLike, AppDbContext>, IPostLikeDal
    {
        public void LikePost(Guid userId, int postId)
        {
            using AppDbContext context = new();

            var postLike = context.PostLikes.FirstOrDefault(x => x.UserId == userId && x.PostId == postId);
            if (postLike == null)
            {
                context.PostLikes.Add(new PostLike
                {
                    UserId = userId,
                    PostId = postId,
                    IsLike= true
                });
            }
            else
            {
                context.PostLikes.Remove(postLike);
            }

            context.SaveChanges();
        }
    }
}
