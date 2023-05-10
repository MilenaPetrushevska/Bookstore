using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Bookstore.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book? Book { get; set; }

        [StringLength(450)]
        [Display(Name = "User")]
        [Required]
        public string? AppUser { get; set; }

        [StringLength(500)]
        public string? Comment { get; set; }

        public int Rating { get; set; }
    }
}
