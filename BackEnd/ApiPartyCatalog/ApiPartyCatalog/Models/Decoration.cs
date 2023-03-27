using System.ComponentModel.DataAnnotations;

namespace ApiPartyCatalog.Models
{
    public class Decoration
    {
        public int DecorationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(5000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(300)]
        public string UrlImage { get; set; }
        public int DecoratorId { get; set; }
        public Decorator Decorator { get; set; }
    }
}
