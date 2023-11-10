﻿using App.Core.DataAccess.EntityFramework;
using App.Core.Entities.Concrete;
using App.DataAccess.Abstract;
using App.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Concrete.EntityFramework
{
  public class EfUserDal : EfEntityRepositoryBase<User, DataContext>, IUserDal
  {
    public List<OperationClaim> GetClaims(User user)
    {
      using (var context = new DataContext())
      {
        var result = from operationClaim in context.OperationClaims
                     join userOperationClaim in context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                     where userOperationClaim.UserId == user.Id
                     select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
        return result.ToList();

      }
    }
  }
}
