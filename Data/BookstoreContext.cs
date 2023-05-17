using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Bookstore.Areas.Identity.Data;

namespace Bookstore.Data
{
    public class BookstoreContext : IdentityDbContext<BookstoreUser>
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<Bookstore.Models.Book> Book { get; set; } = default!;

        public DbSet<Bookstore.Models.Genre>? Genre { get; set; }

        public DbSet<Bookstore.Models.Author>? Author { get; set; }

        public DbSet<Bookstore.Models.Review>? Review { get; set; }

        public DbSet<Bookstore.Models.UserBooks>? UserBooks { get; set; }

        public DbSet<Bookstore.Models.BookGenre> BookGenre { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

