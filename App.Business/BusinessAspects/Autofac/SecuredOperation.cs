using App.Business.Constants;
using App.Core.Extentions;
using App.Core.Utilities.Interceptors;
using App.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.BusinessAspects.Autofac
{
  //JWT icin
  public class SecuredOperation : MethodInterception
  {
  //yetki kontrolu icin lazim
  //su yetkisi varsa falan isleri icin
    private string[] _roles;
    private IHttpContextAccessor _httpContextAccessor; //gets dependency injections

    public SecuredOperation(string roles)
    {
      _roles = roles.Split(',');
      _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

    }

    protected override void OnBefore(IInvocation invocation)
    {
      var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
      foreach (var role in _roles)
      {
        if (roleClaims.Contains(role))
        {
          return;
        }
      }
      throw new Exception(Messages.AuthorizationDenied);
    }
  }
}
