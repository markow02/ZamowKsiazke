using Microsoft.EntityFrameworkCore;
using ZamowKsiazke.Data;

namespace ZamowKsiazke.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ZamowKsiazkeContext(serviceProvider.GetRequiredService<DbContextOptions<ZamowKsiazkeContext>>()))
            {
                if (context.Book.Any())    // Check if database contains any books
                {
                    return;     // Database contains books already
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Bröderna Lejonhjärta",
                        Language = "Swedish",
                        ISBN = "9789129688313",
                        DatePublished = DateTime.Parse("2013-9-26"),
                        Price = 139,
                        Author = "Astrid Lindgren",
                        Description = "A fantasy novel about two brothers who embark on a journey in the land of Nangijala.",
                        ImageUrl = "/images/lejonhjärta.jpg"
                    },

                    new Book
                    {
                        Title = "The Fellowship of the Ring",
                        Language = "English",
                        ISBN = "9780261102354",
                        DatePublished = DateTime.Parse("1991-7-4"),
                        Price = 100,
                        Author = "J. R. R. Tolkien",
                        Description = "The first part of J.R.R. Tolkien's epic adventure The Lord of the Rings.",
                        ImageUrl = "/images/lotr.jpg"
                    },

                    new Book
                    {
                        Title = "Mystic River",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("2011-6-1"),
                        Price = 91,
                        Author = "Dennis Lehane",
                        Description = "A crime thriller about three childhood friends whose lives are shattered by a murder.",
                        ImageUrl = "/images/mystic-river.jpg"
                    },

                    new Book
                    {
                        Title = "Of Mice and Men",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-1-2"),
                        Price = 166,
                        Author = "John Steinbeck",
                        Description = "A novella about the dreams and struggles of two displaced migrant ranch workers.",
                        ImageUrl = "/images/of-mice-and-men.jpg"
                    },

                    new Book
                    {
                        Title = "The Old Man and the Sea",
                        Language = "English",
                        ISBN = "9780062068408",
                        DatePublished = DateTime.Parse("1994-8-18"),
                        Price = 84,
                        Author = "Ernest Hemingway",
                        Description = "A short novel about an aging fisherman who struggles with a giant marlin far out in the Gulf Stream.",
                        ImageUrl = "/images/old-man-and-the-sea.jpg"
                    },

                    new Book
                    {
                        Title = "The Road",
                        Language = "English",
                        ISBN = "9780307386458",
                        DatePublished = DateTime.Parse("2007-5-1"),
                        Price = 95,
                        Author = "Cormac McCarthy",
                        Description = "A post-apocalyptic novel about a father and son's journey through a devastated landscape.",
                        ImageUrl = "/images/the-road.jpg"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
