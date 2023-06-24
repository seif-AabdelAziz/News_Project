using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL;

public class News
{
    public Guid ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string NewsDetails { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime? PublicationDate { get; set; }

    public Guid AuthorID { get; set; }
    public Author? Author { get; set; }
}
