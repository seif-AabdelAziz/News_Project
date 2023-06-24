using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL;

public class NewsReadDTO
{
    public Guid ID { get; set; }
    public string? Title { get; set; } = string.Empty;
    public string? ImageURL { get; set; } = string.Empty;
}
