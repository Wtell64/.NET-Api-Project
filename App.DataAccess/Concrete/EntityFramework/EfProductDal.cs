using App.Core.DataAccess.EntityFramework;
using App.DataAccess.Abstract;
using App.DataAccess.Context;
using App.Entities.Concrete;
using App.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Concrete.EntityFramework
{
  public class EfProductDal : EfEntityRepositoryBase<Product, DataContext>, IProductDal
  {
    public List<ProductDetailDto> GetProductDetails()
    {
      using (DataContext context = new DataContext())
      {

        var result = from p in context.Products
                     join c in context.Categories
                     on p.CategoryId equals c.CategoryId
                     select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock };

        return result.ToList();
      }
    }
  }
}
