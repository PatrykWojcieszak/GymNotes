using GymNotes.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GymNotes.Repository.Base
{
  public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected ApplicationDbContext RepositoryContext { get; set; }
    protected DbSet<T> dbSet;

    public BaseRepository(ApplicationDbContext repositoryContext)
    {
      this.RepositoryContext = repositoryContext;
      this.dbSet = RepositoryContext.Set<T>();
    }

    public IQueryable<T> FindAll()
    {
      return this.RepositoryContext.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
      return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
    }

    public void Create(T entity)
    {
      this.RepositoryContext.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
      //dbSet.Attach(entity);
      //RepositoryContext.Entry(entity).State = EntityState.Modified;
      this.RepositoryContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
      this.RepositoryContext.Set<T>().Remove(entity);
    }
    public void Detach(T entity)
    {
      RepositoryContext.Entry(entity).State = EntityState.Detached;
    }
  }
}