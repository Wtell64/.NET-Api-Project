using App.Core.Entities;
using App.Entities.Concrete;
using App.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Abstract
{
  public interface IProductDal : IEntityRepository<Product>
  {
    List<ProductDetailDto> GetProductDetails();
  }
}
