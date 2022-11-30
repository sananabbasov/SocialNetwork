using Autofac;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Business.Concrete;
using SocialNetwork.DataAccess.Abstract;
using SocialNetwork.DataAccess.Concrete;
using SocialNetwork.DataAccess.Concrete.EntityFramework;

namespace SocialNetwork.Business.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<UserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<PostDal>().As<IPostDal>();
            builder.RegisterType<PostManager>().As<IPostService>();

            builder.RegisterType<PostLikeDal>().As<IPostLikeDal>();
            builder.RegisterType<PostLikeManager>().As<IPostLikeService>();
        }
    }
}