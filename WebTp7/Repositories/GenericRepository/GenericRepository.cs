using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

using WebTp7.Data;

namespace WebTp7.Repositories.GenericRepository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private DbSet<T> table = null;

    public GenericRepository(ApplicationDbContext context)
    {
        _context = context;
        table = _context.Set<T>();
    }

    public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = table;
        foreach (var include in includes)
        {
            query=query.Include(include);
        }
        return query.ToList();
    }
    

    public T GetById(object id, params Expression<Func<T, object>>[] includes)
    {
        // Start with the table.
        IQueryable<T> query = table;

        // Apply includes for eager loading.
        foreach (var include in includes)
        {
            query = query.Include(include);
        }

        // Retrieve the entity by its ID.
        T entity = query.FirstOrDefault(e => EF.Property<object>(e, "Id").Equals(id));

        return entity;
    }
    
    public IEnumerable<T> Find(Func<T, bool> predicate , params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = table;
        
        foreach (var include in includes)
        {
            query=query.Include(include);
        }
        return query.Where(predicate).ToList();
    }
    

    public void Insert(T obj)
    {
        table.Add(obj);
    }

    public void Update(T obj)
    {
        table.Update(obj);
        
    }

    public void Delete(object id)
    {
        T existing = table.Find(id);
        table.Remove(existing);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
    
}