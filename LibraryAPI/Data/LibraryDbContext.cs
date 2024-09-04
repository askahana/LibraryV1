using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace LibraryAPI.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Author = "Astrid Lindgren",
                PublishedYear = 1945,
                Genre = Genre.Children,
                Title = "Pippi Långstrump",
                Description = "Avarable in Swedish",
                IsAvailable = true,

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 2,
                Author = "Jonas Jonasson",
                PublishedYear = 2009,
                Genre = Genre.Children,
                Title = "Hundraåringen som klev ut genom fönstret och försvann",
                Description = "Avarable in Swedish",
                IsAvailable = false,

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 3,
                Author = "Sven Nordqvist",
                PublishedYear = 1984,
                Genre = Genre.Children,
                Title = "Pannkakstårtan",
                Description = "Avarable in Swedish, Pettson och Findus",
                IsAvailable = true,

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 4,
                Author = "Sven Nordqvist",
                PublishedYear = 1990,
                Genre = Genre.Children,
                Title = "Kackel i grönsakslandet ",
                Description = "Avarable in Swedish, Pettson och Findus",
                IsAvailable = true,

            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 5,
                Author = "Fredrik Backman",
                PublishedYear = 2012,
                Genre = Genre.Comedy,
                Title = "En man som heter Ove",
                Description = "Avarable in Swedish",
                IsAvailable = false,
            });
        }

    }
}
