using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL;

public class AuthorEditDTO
{
    public Guid ID { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    [DisplayName("Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime? DOB { get; set; }
    public string? Bio { get; set; }
}
