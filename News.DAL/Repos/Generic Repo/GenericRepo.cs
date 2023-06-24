using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Repos;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly NewsContext newsContext;

    public GenericRepo(NewsContext _newsContext)
    {
        newsContext = _newsContext;
    }

    public List<T> GetAll()
    {
        return newsContext.Set<T>().AsNoTracking().ToList();
    }

    public T? GetByID(Guid id)
    {
        return newsContext.Set<T>().Find(id);
    }

    public void Add(T entity)
    {
        newsContext.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        newsContext.Set<T>().Remove(entity);
    }



}
