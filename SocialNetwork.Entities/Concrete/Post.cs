using SocialNetwork.Core.Entities.Concrete;

namespace SocialNetwork.Entities.Concrete
{
    public class Post
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime PublishDate { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
    }
}