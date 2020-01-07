using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ClassroomContext ClassroomContext { get; set; }

        public RepositoryBase(ClassroomContext ClassroomContext)
        {
            this.ClassroomContext = ClassroomContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.ClassroomContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.ClassroomContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.ClassroomContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ClassroomContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ClassroomContext.Set<T>().Remove(entity);
        }
    }
}
