using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiPartyCatalog.Models
{
    public class Decorator
    {
        public Decorator()
        {
            Decorations = new Collection<Decoration>();
        }

        public int DecoratorId { get; set; }

        [Required]
        [MaxLength(100)]
        public string NameDecorator { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }
        public ICollection<Decoration> Decorations { get; set; }
    }
}
