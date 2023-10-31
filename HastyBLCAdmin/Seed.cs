using Data;
using Data.Models;
using Services.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using System.Text;

namespace HastyBLCAdmin
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HastyDBContext>();

                context?.Database.EnsureCreated();

                // Users
                var user1 = new User()
                {
                    /*Role = role1,*/
                    Username = "hastyuser",
                    Password = PasswordManager.EncryptPassword("hastyuser123"),
                    Email = "hastyuser@gmail.com",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var user2 = new User()
                {
                    /*Role = role2,*/
                    Username = "hastyadmin",
                    Password = PasswordManager.EncryptPassword("hastyadmin123"),
                    Email = "hastyadmin@gmail.com",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var user3 = new User()
                {
                    /*Role = role3,*/
                    Username = "hastysuperadmin",
                    Password = PasswordManager.EncryptPassword("hastysuperadmin123"),
                    Email = "hastysuperadmin@gmail.com",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                if (!context!.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        user1,
                        user2,
                        user3
                    });
                    context.SaveChanges();
                }

                // Authors
                var author1 = new Author()
                {
                    Name = "Elena Armas"
                };
                if (!context!.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        author1
                    });
                    context.SaveChanges();
                }

                // Genres
                var genre1 = new Genre()
                {
                    Name = "Romance",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre2 = new Genre()
                {
                    Name = "Contemporary",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre3 = new Genre()
                {
                    Name = "Sports Romance",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre4 = new Genre()
                {
                    Name = "Sports",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre5 = new Genre()
                {
                    Name = "Contemporary Romance",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                if (!context!.Genres.Any())
                {
                    context.Genres.AddRange(new List<Genre>()
                    {
                        genre1,
                        genre2,
                        genre3,
                        genre4,
                        genre5
                    });
                    context.SaveChanges();
                }

                // Books
                var book1 = new Book()
                {
                    Author = author1,
                    Title = "The Long Game",
                    Description = "A disgraced soccer exec reluctantly enlists the help of a retired soccer star in coaching a children’s team in this smalltown love story in the vein of Ted Lasso and It Happened One Summer —from the New York Times bestselling author of The Spanish Love Deception.\r\n\r\nAdalyn Reyes has spent years perfecting her daily routine: wake up at dawn, drive to the Miami Flames FC offices, try her hardest to leave a mark, go home, and repeat.\r\n\r\nBut her routine is disrupted when a video of her in an altercation with the team’s mascot goes viral. Rather than fire her, the team’s owner—who happens to be her father—sends Adalyn to middle-of-nowhere North Carolina, where she’s tasked with turning around the struggling local soccer team, the Green Warriors, as a way to redeem herself. Her plans crumble upon discovering that the players wear tutus to practice (impractical), keep pet goats (messy), and are terrified of Adalyn (counterproductive), and are nine-year-old kids.\r\n\r\nTo make things worse, also in town is Cameron Caldani, goalkeeping prodigy whose presence is somewhat of a mystery. Cam is the perfect candidate to help Adalyn, but after one very unfortunate first encounter involving a rooster, Cam’s leg, and Adalyn’s bumper, he’s also set on running her out of town. But banishment is not an option for Adalyn. Not again. Helping this ragtag children’s team is her road to redemption, and she is playing the long game. With or without Cam’s help.",
                    Image = "Images/1.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Atria Books",
                    Isbn = "9781668011300",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 384,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                if (!context!.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        book1
                    });
                    context.SaveChanges();
                }

                // BookGenres
                var bookgenre1 = new BookGenre()
                {
                    Book = book1,
                    Genre = genre1,
                };
                var bookgenre2 = new BookGenre()
                {
                    Book = book1,
                    Genre = genre2,
                };
                var bookgenre3 = new BookGenre()
                {
                    Book = book1,
                    Genre = genre3,
                };
                var bookgenre4 = new BookGenre()
                {
                    Book = book1,
                    Genre = genre4,
                };
                var bookgenre5 = new BookGenre()
                {
                    Book = book1,
                    Genre = genre5,
                };
                if (!context!.BookGenres.Any())
                {
                    context.BookGenres.AddRange(new List<BookGenre>()
                    {
                        bookgenre1,
                        bookgenre2,
                        bookgenre3,
                        bookgenre4,
                        bookgenre5
                    });
                    context.SaveChanges();
                }

                // Reviews
                var review1 = new Review()
                {
                    Book = book1,
                    UserName = "reviewer1",
                    UserEmail = "reviewer1@gmail.com",
                    Description = "Very nice book",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                if (!context!.Reviews.Any())
                {
                    context.Reviews.AddRange(new List<Review>()
                    {
                        review1,
                    });
                    context.SaveChanges();
                }

                // Comments
                var comment1 = new Comment()
                {
                    Review = review1,
                    UserName = "reviewer1",
                    UserEmail = "reviewer1@gmail.com",
                    Description = "Very nice review",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                if (!context!.Comments.Any())
                {
                    context.Comments.AddRange(new List<Comment>()
                    {
                        comment1
                    });
                    context.SaveChanges();
                }
            }
        }

    }
}


