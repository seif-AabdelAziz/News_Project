using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.BL;

public class NewsEditDTO
{
    public Guid ID { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    [DisplayName("Description")]
    public string NewsDetails { get; set; } = string.Empty;
    [Required]
    [DisplayName("Image URL")]
    public string ImageUrl { get; set; } = string.Empty;
    [DisplayName("Publication Date")]
    public DateTime? PublicationDate { get; set; }
    [Required]
    [DisplayName("Author")]
    public Guid AuthorID { get; set; }
}
