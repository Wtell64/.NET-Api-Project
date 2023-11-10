using App.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
  public class Customer : IEntity
  {
  public string CustomerId { get; set; }
  public string CustomerName { get; set;}

  public string CompanyName { get; set;}

  public string City { get; set;}
  }
}
