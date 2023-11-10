using App.Core.DataAccess.EntityFramework;
using App.DataAccess.Abstract;
using App.DataAccess.Context;
using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Concrete.EntityFramework
{
  public class EfCategoryDal : EfEntityRepositoryBase<Category, DataContext>, ICategoryDal
  {
   
  }
}
