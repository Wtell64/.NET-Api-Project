using App.Core.CrossCuttingConcerns.Caching;
using App.Core.Utilities.Interceptors;
using App.Core.Utilities.IoC;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace App.Core.Aspects.Autofac.Caching
{
  public class CacheRemoveAspect : MethodInterception
  {
    private string _pattern;
    private ICacheManager _cacheManager;

    public CacheRemoveAspect(string pattern)
    {
      _pattern = pattern;
      _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    protected override void OnSuccess(IInvocation invocation)
    {
      _cacheManager.RemoveByPattern(_pattern);
    }
  }
}
