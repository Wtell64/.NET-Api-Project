using App.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Entities
{
  public interface IEntityRepository<T>
  //generic constraint
  //class: referans tip olabilir
  //new: newlenebilir olmali
  where T : class, IEntity, new()
  {
    List<T> GetAll(Expression<Func<T,bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);

    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);

  }
}
