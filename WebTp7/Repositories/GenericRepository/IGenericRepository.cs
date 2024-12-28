using System.Linq.Expressions;

namespace WebTp7.Repositories.GenericRepository;

public interface IGenericRepository <T> where T : class
{
    IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
    
    T GetById(object id , params Expression<Func<T, object>>[] includes );
    
    IEnumerable<T> Find(Func<T, bool> predicate, params Expression<Func<T, object>>[] includes);
    void Insert(T obj);
    void Update(T obj);
    void Delete(object id);
    
    void Save();
    
}