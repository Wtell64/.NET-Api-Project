using App.Business.Abstract;
using App.Business.CCS;
using App.Business.Concrete;
using App.Core.Utilities.Interceptors;
using App.Core.Utilities.Security.JWT;
using App.DataAccess.Abstract;
using App.DataAccess.Concrete.EntityFramework;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//autofac ve autofac.extras
namespace App.Business.DependencyResolvers.Autofac
{
  public class AutofacBusinessModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
      builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

      builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
      builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

      builder.RegisterType<UserManager>().As<IUserService>();
      builder.RegisterType<EfUserDal>().As<IUserDal>();

      builder.RegisterType<AuthManager>().As<IAuthService>();
      builder.RegisterType<JwtHelper>().As<ITokenHelper>();

      

      var assembly = System.Reflection.Assembly.GetExecutingAssembly();

      builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
          .EnableInterfaceInterceptors(new ProxyGenerationOptions()
          {
            Selector = new AspectInterceptorSelector()
          }).SingleInstance();

    }
  }
}
