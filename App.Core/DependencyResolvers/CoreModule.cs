using App.Core.CrossCuttingConcerns.Caching;
using App.Core.CrossCuttingConcerns.Caching.Microsoft;
using App.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.DependencyResolvers
{
  public class CoreModule : ICoreModule
  {
    public void Load(IServiceCollection serviceCollection)
    {
      serviceCollection.AddMemoryCache();

      serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      serviceCollection.AddSingleton<ICacheManager,MemoryCacheManager>();
      serviceCollection.AddSingleton<Stopwatch>();
      
    }
  }
}
