using Microsoft.EntityFrameworkCore;
using SocialNetwork.Core.Entities.Concrete;
using SocialNetwork.Entities.Concrete;

namespace SocialNetwork.DataAccess.Concrete
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=127.0.0.1,1433;Database=SocialNetworkDB; User Id=SA; Password=Qwerty123; TrustServerCertificate=True;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
    }
}