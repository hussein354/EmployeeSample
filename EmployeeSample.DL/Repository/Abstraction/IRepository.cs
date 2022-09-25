using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSample.DL.Repos.Abstraction
{
    using EmployeeSample.DL.Entities;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    namespace GR.Data
    {
        public interface IRepository<T> where  T : BaseEntity
        {
            IQueryable<T> GetAll();
            IQueryable<T> Get( Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
            bool Insert(T entity);
            bool Update(T entity);
            bool Delete(T entity);
        }
    }
}
