using Microsoft.AspNetCore.Mvc.Rendering;
using Bookstore.Models;

namespace Bookstore.ViewModels
{
    public class BookGenresCreateViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<int>? SelectedGenreIds { get; set; }
        public IEnumerable<SelectListItem>? GenreList { get; set; }
    }
}
