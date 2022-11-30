using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.DataAccess.EntityFramework;
using SocialNetwork.Core.Entities.Concrete;
using SocialNetwork.DataAccess.Abstract;
using static SocialNetwork.Entities.DTOs.PostDTO;

namespace SocialNetwork.DataAccess.Concrete
{
    public class UserDal : EfRepositoryBase<User, AppDbContext>, IUserDal
    {
        public IEnumerable<ProfilePostListDTO> GetUserProfilePosts(Guid userId)
        {
            using var context = new AppDbContext();
            List<ProfilePostListDTO> result= new();
            var posts = context.Posts.Include(x=>x.PostLikes).Where(x=>x.UserId== userId).ToList();
            foreach (var post in posts)
            {
                int likeCount = post.PostLikes.Where(x => x.IsLike == true).Count();
                ProfilePostListDTO postListDTO = new(post.Id,post.Content, likeCount);
                result.Add(postListDTO);
            }
            return result;
        }
    }
}