using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // Generic Constraint ( Genel Kısıtlama )
    // class : referans tip olabilir anlamına gelmektedir.
    // IEntity :IEntity olabilir veye IEntity implemente eden bir nesne olabilir.
    // new() : new'lenebilir olmalıdır.
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
