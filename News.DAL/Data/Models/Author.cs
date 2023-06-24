using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DAL;

public class Author
{
    public Guid ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? DOB { get; set; }
    public string? Bio { get; set; } = string.Empty;

    public List<News> News { get; set; } = new List<News>();
}
