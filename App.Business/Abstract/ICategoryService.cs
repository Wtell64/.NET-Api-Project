﻿using App.Core.Utilities.Results;
using App.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Abstract
{
  public interface ICategoryService
  {

    IDataResult<List<Category>> GetAll();

    IDataResult<Category> GetById(int categoryId);
  
    
    }
}