using News.DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL;

public class UnitOfWork : IUnitOfWork
{
    public INewsRepo NewsRepo { get; }
    public IAuthorRepo AuthorsRepo { get; }

    private readonly NewsContext newsContext;

    public UnitOfWork(NewsContext _newsContext,
        INewsRepo _newsRepo,
        IAuthorRepo _authorRepo)
    {
        newsContext = _newsContext;
        NewsRepo = _newsRepo;
        AuthorsRepo = _authorRepo;
    }

    public int Save()
    {
        return newsContext.SaveChanges();
    }
}
