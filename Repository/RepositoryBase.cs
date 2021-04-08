using System;
using System.Linq;
using System.Linq.Expressions;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Contracts;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected ApplicationContext ApplicationContext { get; set; }

        public RepositoryBase(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges
                ? ApplicationContext.Set<T>()
                    .AsNoTracking()
                : ApplicationContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
                !trackChanges
                    ? ApplicationContext.Set<T>()
                        .Where(expression)
                        .AsNoTracking()
                    : ApplicationContext.Set<T>()
                        .Where(expression);

        public void Create(T entity) => ApplicationContext.Add(entity);

        public void Update(T entity) => ApplicationContext.Update(entity);

        public void Delete(T entity) => ApplicationContext.Remove(entity);
    }
}