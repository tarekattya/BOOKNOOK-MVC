using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCP_BookStore.Models
{
    public class BookStoreDBContext : IdentityDbContext <DefaultUser>
    {
        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
            :base(options) { }

     
       

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Bröderna Lejonhjärta",
                    Language = "Swedish",
                    ISBN = "9789129688313",
                    DatePublished = DateTime.Parse("2013-9-26"),
                    Price = 139,
                    Author = "Astrid Lindgren",
                    ImageUrl = "/images/lejonhjärta.jpg",
                    Description="loreim ipsum"

                },

                    new Book
                    {
                        Id = 2,
                        Title = "The Fellowship of the Ring",
                        Language = "English",
                        ISBN = "9780261102354",
                        DatePublished = DateTime.Parse("1991-7-4"),
                        Price = 100,
                        Author = "J. R. R. Tolkien",
                        Description = "loreim ipsum",
                        ImageUrl = "/images/lotr.jpg"
                    },

                    new Book
                    {
                        Id = 3,
                        Title = "Mystic River",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("2011-6-1"),
                        Price = 91,
                        Author = "Dennis Lehane",
                        ImageUrl = "/images/mystic-river.jpg",
                         Description = "loreim ipsum"
                    },

                    new Book
                    {
                        Id = 4,
                        Title = "Of Mice and Men",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-1-2"),
                        Price = 166,
                        Author = "John Steinbeck",
                        ImageUrl = "/images/of-mice-and-men.jpg",
                        Description = "loreim ipsum"
                    },

                    new Book
                    {
                        Id = 5,
                        Title = "The Old Man and the Sea",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-8-18"),
                        Price = 84,
                        Author = "Ernest Hemingway",
                        ImageUrl = "/images/old-man-and-the-sea.jpg",
                        Description = "loreim ipsum"
                    },

                    new Book
                    {
                        Id = 6,
                        Title = "The Road",
                        Language = "English",
                        ISBN = "9780307386458",
                        DatePublished = DateTime.Parse("2007-5-1"),
                        Price = 95,
                        Author = "Cormac McCarthy",
                        ImageUrl = "/images/the-road.jpg"
                        ,
                        Description = "loreim ipsum"
                    },
                    new Book
                    {
                        Id = 7,
                        Title = "Battlefield of the mind",
                        Language = "English",
                        ISBN = "9780307386458",
                        DatePublished = DateTime.Parse("2007-5-1"),
                        Price = 180,
                        Author = "Cormac McCarthy",
                        ImageUrl = "/images/Battelfield.jpg"
                        ,
                        Description = "loreim ipsum"
                    },
                    new Book
                    {
                        Id = 8,
                        Title = "Dont Believe Everything You Think",
                        Language = "English",
                        ISBN = "9780307386458",
                        DatePublished = DateTime.Parse("2008-6-1"),
                        Price = 95,
                        Author = "Cormac McCarthy",
                        ImageUrl = "/images/Dont believe.jpg"
                        ,
                        Description = "loreim ipsum"
                    },
                    new Book
                    {
                        Id =9,
                        Title = "Fly It Like you Stole It",
                        Language = "English",
                        ISBN = "9780307381122",
                        DatePublished = DateTime.Parse("2017-9-1"),
                        Price = 225,
                        Author = "Cormac McCarthy",
                        ImageUrl = "/images/flyIt like.jpg"
                        ,
                        Description = "loreim ipsum"
                    }, 
                    new Book
                    {
                        Id = 10,
                        Title = "Harry Potter:JK Rowling ",
                        Language = "English",
                        ISBN = "8899307381122",
                        DatePublished = DateTime.Parse("2017-10-1"),
                        Price = 225,
                        Author = "Cormac McCarthy",
                        ImageUrl = "/images/HarryPotter.jpg"
                        ,
                        Description = "loreim ipsum"
                    },
                     new Book
                     {
                         Id = 11,
                         Title = "How to Talk to AnyOne ",
                         Language = "English",
                         ISBN = "8899307381122",
                         DatePublished = DateTime.Parse("2017-10-1"),
                         Price = 225,
                         Author = "Agatha McCarthy",
                         ImageUrl = "/images/how to talk.jpg"
                        ,
                         Description = "loreim ipsum"
                     }, new Book
                     {
                         Id = 12,
                         Title = "Inner Excellence ",
                         Language = "English",
                         ISBN = "8899397381122",
                         DatePublished = DateTime.Parse("2017-10-1"),
                         Price = 225,
                         Author = "Cormac McCarthy",
                         ImageUrl = "/images/inner exellience.jpg"
                        ,
                         Description = "loreim ipsum"
                     }, new Book
                     {
                         Id = 13,
                         Title = "Iron Flame  ",
                         Language = "English",
                         ISBN = "8899307381122",
                         DatePublished = DateTime.Parse("2017-10-1"),
                         Price = 400,
                         Author = "Ernest Hemingway",
                         ImageUrl = "/images/IronFlame.webp"
                        ,
                         Description = "loreim ipsum"
                     },
                     new Book
                     {
                         Id = 14,
                         Title = "Rich Dad Poor Dad ",
                         Language = "English",
                         ISBN = "8899307381122",
                         DatePublished = DateTime.Parse("2017-10-1"),
                         Price = 225,
                         Author = "Cormac McCarthy",
                         ImageUrl = "/images/RichDad.webp"
                        ,
                         Description = "loreim ipsum"
                     },
                     new Book
                     {
                         Id = 15,
                         Title = "Source Code",
                         Language = "English",
                         ISBN = "8899307381122",
                         DatePublished = DateTime.Parse("2017-10-1"),
                         Price = 225,
                         Author = "Cormac McCarthy",
                         ImageUrl = "/images/Source code.jpg"
                        ,
                         Description = "loreim ipsum"
                     },
                       new Book
                       {
                           Id = 16,
                           Title = "The Way Of Superior Man",
                           Language = "English",
                           ISBN = "8899307381122",
                           DatePublished = DateTime.Parse("2018-10-6"),
                           Price = 225,
                           Author = "Cormac McCarthy",
                           ImageUrl = "/images/theWay.jpg"
                        ,
                           Description = "loreim ipsum"
                       },
                       new Book
                       {
                           Id = 17,
                           Title = "Trading In The Zone",
                           Language = "English",
                           ISBN = "8899307381122",
                           DatePublished = DateTime.Parse("2018-10-6"),
                           Price = 300,
                           Author = "Cormac McCarthy",
                           ImageUrl = "/images/tradinig in thezone.jpg"
                        ,
                           Description = "loreim ipsum"
                       },
                       new Book
                       {
                           Id = 18,
                           Title = "You Become What You Think about",
                           Language = "English",
                           ISBN = "8899307381122",
                           DatePublished = DateTime.Parse("2018-10-6"),
                           Price = 300,
                           Author = "Cormac McCarthy",
                           ImageUrl = "/images/You Become What You Think about.jpg"
                        ,
                           Description = "loreim ipsum"
                       }
            );
        }


        public  DbSet<Book> Books { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems  { get; set; }
    }
}
