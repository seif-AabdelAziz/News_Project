using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Repos;

public class AuthorRepo : GenericRepo<Author>, IAuthorRepo
{
    private readonly NewsContext newsContext;

    public AuthorRepo(NewsContext _newsContext) : base(_newsContext)
    {
        newsContext = _newsContext;
    }
}
