using HastyBLC.Models;

namespace HastyBLC.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context?.Database.EnsureCreated();

                // Roles
                var role1 = new Role()
                {
                    Name = "user"
                };
                var role2 = new Role()
                {
                    Name = "admin"
                };
                if (!context!.Roles.Any())
                {                  
                    context.Roles.AddRange(new List<Role>()
                    {
                        role1, 
                        role2
                    });
                    context.SaveChanges();
                }

                // Attributes
                var attribute1 = new Models.Attribute()
                {
                    Name = "HasPrivilege",
                    Type = "bool"
                };
                if (!context!.Attributes.Any())
                {
                    context.Attributes.AddRange(new List<Models.Attribute>()
                    {
                        attribute1
                    });
                    context.SaveChanges();
                }

                // RoleAttributes
                var roleattribute1 = new Models.RoleAttribute()
                {
                    Role = role2,
                    Attribute = attribute1
                };
                if (!context!.RoleAttributes.Any())
                {
                    context.RoleAttributes.AddRange(new List<RoleAttribute>()
                    {
                        roleattribute1
                    });
                    context.SaveChanges();
                }

                // Users
                var user1 = new User()
                {
                    Role = role1,
                    Username = "hastyuser",
                    Password = "hastyuser123",
                    Email = "hastyuser@gmail.com"
                };
                var user2 = new User()
                {
                    Role = role2,
                    Username = "hastyadmin",
                    Password = "hastyadmin123",
                    Email = "hastyadmin@gmail.com"
                };
                if (!context!.Users.Any())
                {
                    context.Users.AddRange(new List<User>()
                    {
                        user1,
                        user2
                    });
                    context.SaveChanges();
                }

                // UserRoleAttributes
                if (!context!.UserRoleAttributes.Any())
                {
                    context.UserRoleAttributes.AddRange(new List<UserRoleAttribute>()
                    {
                        new UserRoleAttribute()
                        {
                            User = user2,
                            RoleAttribute = roleattribute1,
                            Value = "True"
                        }
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
                    Name = "Romance"
                };
                var genre2 = new Genre()
                {
                    Name = "Contemporary"
                };
                var genre3 = new Genre()
                {
                    Name = "Sports Romance"
                };
                var genre4 = new Genre()
                {
                    Name = "Sports"
                };
                var genre5 = new Genre()
                {
                    Name = "Contemporary Romance"
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
                    Pages = 384
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

                // Ratings
                var rating1 = new Rating()
                {
                    User = user1,
                    Book = book1,
                    Value = 5
                };
                if (!context!.Ratings.Any())
                {
                    context.Ratings.AddRange(new List<Rating>()
                    {
                        rating1,
                    });
                    context.SaveChanges();
                }

                // Reviews
                var review1 = new Review()
                {
                    Rating = rating1,
                    Description = "Very nice book"
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
                    User = user1,
                    Review = review1,
                    Description = "Very nice review"
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
