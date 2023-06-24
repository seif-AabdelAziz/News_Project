using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Repos;

public class NewsRepo : GenericRepo<News>, INewsRepo
{
    private readonly NewsContext newsContext;

    public NewsRepo(NewsContext _newsContext) : base(_newsContext)
    {
        newsContext = _newsContext;
    }


    public List<News> PublishedNews()
    {
        return newsContext.Set<News>().AsNoTracking()
            .Where(n => n.PublicationDate == DateTime.Now || n.PublicationDate < DateTime.Now)
            .ToList();
    }
    public News? NewsDetails(Guid id)
    {
        return newsContext.Set<News>()
            .Include(a => a.Author)
            .FirstOrDefault(n => n.ID == id);
    }

    public List<News> GetAllWithAuthors()
    {
        return newsContext.Set<News>()
            .Include(a => a.Author)
            .ToList();
    }
}
