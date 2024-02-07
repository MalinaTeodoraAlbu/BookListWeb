using BookListWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookListWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Drama", DisplayOrder = 2 },
               new Category { Id = 3, Name = "SciFi", DisplayOrder = 3 },
               new Category { Id = 4, Name = "History", DisplayOrder = 4 },
               new Category { Id = 5, Name = "Adventure", DisplayOrder = 5 },
               new Category { Id = 6, Name = "Kids", DisplayOrder = 6 }
               );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Murder on the Orient Express", Description = "A classic detective novel featuring Hercule Poirot.", Author = "Agatha Christie", Rating = 4.7f, yearOfPublication = 1934, CategoryId = 1, ImageUrl = "https://example.com/murder_on_orient_express.jpg" },
                new Book { Id = 2, Title = "And Then There Were None", Description = "A suspenseful mystery with an isolated setting and a deadly plot.", Author = "Agatha Christie", Rating = 4.8f, yearOfPublication = 1939, CategoryId = 2, ImageUrl = "https://example.com/and_then_there_were_none.jpg" },
                new Book { Id = 3, Title = "Red Queen", Description = "Victoria Aveyard's gripping tale of power, betrayal, and rebellion.", Author = "Victoria Aveyard", Rating = 4.5f, yearOfPublication = 2015, CategoryId = 3, ImageUrl = "https://example.com/red_queen.jpg" },
                new Book { Id = 4, Title = "Glass Sword", Description = "The sequel to Red Queen, continuing the story of Mare Barrow.", Author = "Victoria Aveyard", Rating = 4.4f, yearOfPublication = 2016, CategoryId = 4, ImageUrl = "https://example.com/glass_sword.jpg" },
                new Book { Id = 5, Title = "Agatha Christie: An Autobiography", Description = "Agatha Christie's personal account of her life and career.", Author = "Agatha Christie", Rating = 4.6f, yearOfPublication = 1977, CategoryId = 5, ImageUrl = "https://example.com/agatha_christie_autobiography.jpg" },
                new Book { Id = 6, Title = "King's Cage", Description = "The third book in the Red Queen series by Victoria Aveyard.", Author = "Victoria Aveyard", Rating = 4.3f, yearOfPublication = 2017, CategoryId = 6, ImageUrl = "https://example.com/kings_cage.jpg" },
                new Book { Id = 7, Title = "Death on the Nile", Description = "Another classic Hercule Poirot mystery by Agatha Christie.", Author = "Agatha Christie", Rating = 4.9f, yearOfPublication = 1937, CategoryId = 1, ImageUrl = "https://example.com/death_on_the_nile.jpg" },
                new Book { Id = 8, Title = "War Storm", Description = "The final installment in Victoria Aveyard's Red Queen series.", Author = "Victoria Aveyard", Rating = 4.2f, yearOfPublication = 2018, CategoryId = 2, ImageUrl = "https://example.com/war_storm.jpg" },
                new Book { Id = 9, Title = "The Murder of Roger Ackroyd", Description = "A groundbreaking mystery novel by Agatha Christie.", Author = "Agatha Christie", Rating = 4.7f, yearOfPublication = 1926, CategoryId = 3, ImageUrl = "https://example.com/murder_of_roger_ackroyd.jpg" },
                new Book { Id = 10, Title = "Realm Breaker", Description = "Victoria Aveyard's fantasy novel with a unique world and characters.", Author = "Victoria Aveyard", Rating = 4.1f, yearOfPublication = 2021, CategoryId = 4, ImageUrl = "https://example.com/realm_breaker.jpg" }
            );
        }


    }
}
