using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL.Repos;

public interface INewsRepo : IGenericRepo<News>
{
    List<News> PublishedNews();
    News? NewsDetails(Guid id);
    List<News> GetAllWithAuthors();

}
