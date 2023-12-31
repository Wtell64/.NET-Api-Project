﻿using App.Core.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Entities.Concrete
{
  public class Product : IEntity
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

  public int CategoryId { get; set; }

  public string ProductName { get; set; }

  public short UnitsInStock { get; set; }

  public decimal UnitPrice { get; set; }
  }
}
