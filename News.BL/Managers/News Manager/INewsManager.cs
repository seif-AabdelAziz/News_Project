using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using News.BL;

namespace News.BL;

public interface INewsManager
{
    List<NewsReadDTO> ReadPublished();
    NewsReadDetailsDTO? ReadDetails(Guid id);
    List<NewsReadDetailsDTO> ReadAll();
    public int Add(NewsAddDTO newsAddDTO);
    NewsEditDTO? EditNews(Guid id);
    public int Update(NewsEditDTO newsEditDTO);
    public int Delete(Guid id);
}
