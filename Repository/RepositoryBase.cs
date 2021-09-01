using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _Context;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _Context = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? _Context.Set<T>().AsNoTracking() : _Context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? _Context.Set<T>().Where(expression).AsNoTracking() :_Context.Set<T>().Where(expression);
        public void Create(T entity) => _Context.Set<T>().Add(entity);
        public void Update(T entity) => _Context.Set<T>().Update(entity);
        public void Delete(T entity) => _Context.Set<T>().Remove(entity);

        public async Task SaveChangeAsync() => await _Context.SaveChangesAsync();
    }

}
