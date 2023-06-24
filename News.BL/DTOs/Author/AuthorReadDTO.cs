using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL;

public class AuthorReadDTO
{
    public Guid ID { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? DOB { get; set; }
    public string? Bio { get; set; } = string.Empty;
}
