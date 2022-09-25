using EmployeeSample.DL.Contexts;
using EmployeeSample.DL.Entities;
using EmployeeSample.DL.Repos.Abstraction.GR.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeSample.DL.Repos
{

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EmployeeDbContext context;
        private DbSet<T> entities;
        public Repository(EmployeeDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return entities.AsSingleQuery();
        }
        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = entities;

            if (filter is not null)
            {
                query = query.Where(filter).AsQueryable();
            }
            if(orderBy is not null )
            {
                return orderBy(query).AsQueryable();
            }
            return query;
        }
        public bool Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if(entity is {IsDeleted=true } )
            entities.Add(entity);

            if (context.SaveChanges() > 0) return true;
            return false;
        }
        public bool Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (context.SaveChanges() > 0) return true;
            return false;
        }
        public bool Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Remove(entity);
            if (context.SaveChanges() > 0) return true;
            return false;
        }
    }
}

