using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DnD.Datalayer.Context;
using DnD.Datalayer.Repositories;


public class BaseRepository<T> : IRepository<T>, IDisposable where T : class
{
    private IDbSet<T> _entities;
    protected DnDContext Context;
    private bool disposed;

    public BaseRepository(DnDContext context)
    {
        Context = context;
    }

    protected IDbSet<T> DbSet
    {
        get
        {
            if (_entities == null)
            {
                _entities = Context.Set<T>();
            }
            return _entities;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public virtual IQueryable<T> All()
    {
        return DbSet.AsQueryable();
    }

    public virtual T Create(T obj)
    {
        var newEntry = DbSet.Add(obj);

        try
        {
            Context.SaveChanges();
        }
        catch (DbEntityValidationException dbEx)
        {
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    Trace.TraceInformation(
                        "Property: {0} Error: {1}",
                        validationError.PropertyName,
                        validationError.ErrorMessage);
                }
            }
        }

        return newEntry;
    }

    public virtual int Delete(T obj)
    {
        DbSet.Remove(obj);
        return Context.SaveChanges();
    }

    public virtual int Delete(Expression<Func<T, bool>> predicate)
    {
        var objects = Filter(predicate);

        foreach (var obj in objects)
        {
            DbSet.Remove(obj);
        }

        return Context.SaveChanges();
    }

    public virtual IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
    {
        return DbSet.Where(predicate).AsQueryable();
    }

    public virtual IQueryable<T> Filter<TKey>(
        Expression<Func<T, bool>> filter,
        out int total,
        int index = 0,
        int size = 50)
    {
        var skipCount = index * size;
        var resetSet = filter != null ? DbSet.Where(filter).AsQueryable() : DbSet.AsQueryable();
        resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);

        total = resetSet.Count();

        return resetSet.AsQueryable();
    }

    public T Find(int id)
    {
        return DbSet.Find(id);
    }

    public virtual T Find(params object[] keys)
    {
        return DbSet.Find(keys);
    }

    public virtual T Find(Expression<Func<T, bool>> predicate)
    {
        return DbSet.FirstOrDefault(predicate);
    }

    public virtual void Ignore(T t)
    {
        Context.Entry(t).State = EntityState.Unchanged;
    }

    public virtual int Update(T obj)
    {
        var entry = Context.Entry(obj);
        DbSet.Attach(obj);
        entry.State = EntityState.Modified;
        return 0;
    }

    public virtual void Save()
    {
        Context.SaveChanges();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
        }

        disposed = true;
    }

    ~BaseRepository()
    {
        Dispose(false);
    }
}

