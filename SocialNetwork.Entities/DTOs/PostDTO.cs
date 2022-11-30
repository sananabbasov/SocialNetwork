using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities.DTOs
{
    public class PostDTO
    {
        public record PostCreateDTO(string Content);
        public record PostDeleteDTO(int Id);
        public record ProfilePostListDTO(int postId,string Content, int LikeCount);
    }
}
