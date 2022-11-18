using Autofac;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Business.Concrete;

namespace SocialNetwork.Business.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>();
        }
    }
}