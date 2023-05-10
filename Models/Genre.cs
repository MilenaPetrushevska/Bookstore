using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bookstore.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name = "Name of Genre")]
        [Required]
        [StringLength(50)]
        public string? GenreName { get; set; }

        public ICollection<BookGenre>? Books { get; set; }
    }
}
