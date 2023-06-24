using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Repos;

public interface IGenericRepo<T> where T : class
{
    List<T> GetAll();
    T? GetByID(Guid id);
    void Delete(T entity);
    void Add(T entity);
}
