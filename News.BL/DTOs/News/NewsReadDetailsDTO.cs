using News.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL;

public class NewsReadDetailsDTO
{
    public Guid ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? NewsDetails { get; set; } = string.Empty;
    public string? ImageUrl { get; set; } = string.Empty;
    public DateTime? PublicationDate { get; set; }

    public string? AuthorName { get; set; } = string.Empty;


}
