using App.Core.Entities.Concrete;
using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Abstract
{
  public interface IUserDal : IEntityRepository<User>
  {
    List<OperationClaim> GetClaims(User user);
  }
}
