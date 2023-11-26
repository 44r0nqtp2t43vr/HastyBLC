using Data;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Services.Interfaces;
using Services.Services;

namespace HastyBLCAdmin
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HastyDBContext>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<IdentityUser>>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                context?.Database.EnsureCreated();

                // AspNetRoles
                var role1 = new IdentityRole()
                {
                    Name = "Superadmin"
                };

                roleManager!.CreateAsync(role1).Wait();

                // AspNetUsers
                var aspuser1 = new IdentityUser()
                {
                    Email = "superadmin@gmail.com",
                    UserName = "superadmin"
                };
                userManager!.CreateAsync(aspuser1, "Superadmin123!").Wait();

                // AspNetUserRoles
                userManager.AddToRoleAsync(aspuser1, "Superadmin").Wait();

                // Authors
                var author1 = new Author()
                {
                    Name = "Elena Armas"
                };
                var author2 = new Author()
                {
                    Name = "Breanne Randall"
                };
                var author3 = new Author()
                {
                    Name = "Jennifer L. Armentrout"
                };
                var author4 = new Author()
                {
                    Name = "Kate Goldbeck"
                };
                var author5 = new Author()
                {
                    Name = "Beth O’Leary"
                };
                var author6 = new Author()
                {
                    Name = "Meryl Wilsner"
                };
                var author7 = new Author()
                {
                    Name = "Millie Bobby Brown"
                };
                var author8 = new Author()
                {
                    Name = "Chloe Gong"
                };
                var author9 = new Author()
                {
                    Name = "Shelby Mahurin"
                };
                var author10 = new Author()
                {
                    Name = "Meg Cabot"
                };
                var author11 = new Author()
                {
                    Name = "V.E. Schwab"
                };
                var author12 = new Author()
                {
                    Name = "Jessica Knoll"
                };
                var author13 = new Author()
                {
                    Name = "Richard Osman"
                };
                var author14 = new Author()
                {
                    Name = "Mona Awad"
                };
                var author15 = new Author()
                {
                    Name = "Etaf Rum"
                };
                var author16 = new Author()
                {
                    Name = "Lauren Groff"
                };
                var author17 = new Author()
                {
                    Name = "Rachel Harrison"
                };
                var author18 = new Author()
                {
                    Name = "Rick Riordan"
                };
                var author19 = new Author()
                {
                    Name = "Zadie Smith"
                };
                var author20 = new Author()
                {
                    Name = "John Scalzi"
                };
                var author21 = new Author()
                {
                    Name = "Lauren Munoz"
                };
                var author22 = new Author()
                {
                    Name = "Kayvion Lewis"
                };
                var author23 = new Author()
                {
                    Name = "Susan Lee"
                };
                var author24 = new Author()
                {
                    Name = "Ally Condie"
                };
                var author25 = new Author()
                {
                    Name = "Andrew Joseph White"
                };
                var author26 = new Author()
                {
                    Name = "Kathryn Purdie"
                };
                var author27 = new Author()
                {
                    Name = "Kalyn Josephson"
                };
                var author28 = new Author()
                {
                    Name = "Lisa Springer"
                };
                var author29 = new Author()
                {
                    Name = "Miranda Sun"
                };
                var author30 = new Author()
                {
                    Name = "Kendare Blake"
                };
                var author31 = new Author()
                {
                    Name = "Hannah Nicole Maerhrer"
                };
                var author32 = new Author()
                {
                    Name = "K.A. Tucker"
                };
                var author33 = new Author()
                {
                    Name = "Ariel Kaplan"
                };
                var author34 = new Author()
                {
                    Name = "Laura Shepherd-Robinson"
                };
                var author35 = new Author()
                {
                    Name = "Paige Crutcher"
                };
                var author36 = new Author()
                {
                    Name = "Tori Anne Martin"
                };
                var author37 = new Author()
                {
                    Name = "Kell Woods"
                };
                var author38 = new Author()
                {
                    Name = "Adam Mansbach"
                };
                var author39 = new Author()
                {
                    Name = "Chuck Wendig"
                };
                var author40 = new Author()
                {
                    Name = "John Connolly"
                };
                var author41 = new Author()
                {
                    Name = "C Pam Zhang"
                };
                var author42 = new Author()
                {
                    Name = "Stephanie Oakes"
                };
                var author43 = new Author()
                {
                    Name = "Justin C. Key"
                };
                var author44 = new Author()
                {
                    Name = "Dwain Worell"
                };
                var author45 = new Author()
                {
                    Name = "A.S. King"
                };
                var author46 = new Author()
                {
                    Name = "Sim Kern"
                };
                var author47 = new Author()
                {
                    Name = "Emily Skrutskie"
                };
                var author48 = new Author()
                {
                    Name = "Katherine Applegate"
                };
                var author49 = new Author()
                {
                    Name = "Natalie Haynes"
                };
                var author50 = new Author()
                {
                    Name = "Charlaine Harris"
                };

                if (!context!.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        author1,
                        author2,
                        author3,
                        author4,
                        author5,
                        author6,
                        author7,
                        author8,
                        author9,
                        author10,
                        author11,
                        author12,
                        author13,
                        author14,
                        author15,
                        author16,
                        author17,
                        author18,
                        author19,
                        author20,
                        author21,
                        author22,
                        author23,
                        author24,
                        author25,
                        author26,
                        author27,
                        author28,
                        author29,
                        author30,
                        author31,
                        author32,
                        author33,
                        author34,
                        author35,
                        author36,
                        author37,
                        author38,
                        author39,
                        author40,
                        author41,
                        author42,
                        author43,
                        author44,
                        author45,
                        author46,
                        author47,
                        author48,
                        author49,
                        author50,
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
                var genre6 = new Genre()
                {
                    Name = "Fantasy",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre7 = new Genre()
                {
                    Name = "Witches",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre8 = new Genre()
                {
                    Name = "Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre9 = new Genre()
                {
                    Name = "Halloween",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre10 = new Genre()
                {
                    Name = "Fantasy Romance",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre11 = new Genre()
                {
                    Name = "Adult",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre12 = new Genre()
                {
                    Name = "LGBT",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre13 = new Genre()
                {
                    Name = "Audiobook",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre14 = new Genre()
                {
                    Name = "Christmas",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre15 = new Genre()
                {
                    Name = "Chick Lit",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre16 = new Genre()
                {
                    Name = "Holiday",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre17 = new Genre()
                {
                    Name = "Lesbian",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre18 = new Genre()
                {
                    Name = "Queer",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre19 = new Genre()
                {
                    Name = "Sports",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre20 = new Genre()
                {
                    Name = "Historical Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre21 = new Genre()
                {
                    Name = "Historical",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre22 = new Genre()
                {
                    Name = "World War II",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre23 = new Genre()
                {
                    Name = "Young Adult",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre24 = new Genre()
                {
                    Name = "Mystery",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre25 = new Genre()
                {
                    Name = "Vampires",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre26 = new Genre()
                {
                    Name = "Young Adult Fantasy",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre27 = new Genre()
                {
                    Name = "Paranormal",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre28 = new Genre()
                {
                    Name = "Magic",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre29 = new Genre()
                {
                    Name = "Paranormal Romance",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre30 = new Genre()
                {
                    Name = "High Fantasy",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre31 = new Genre()
                {
                    Name = "Science Fiction Fantasy",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre32 = new Genre()
                {
                    Name = "Thriller",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre33 = new Genre()
                {
                    Name = "Mystery Thriller",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre34 = new Genre()
                {
                    Name = "Crime",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre35 = new Genre()
                {
                    Name = "Cozy Mystery",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre36 = new Genre()
                {
                    Name = "Horror",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre37 = new Genre()
                {
                    Name = "Gothic",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre38 = new Genre()
                {
                    Name = "Literary Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre39 = new Genre()
                {
                    Name = "Mental Health",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre40 = new Genre()
                {
                    Name = "Adult Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre41 = new Genre()
                {
                    Name = "Nature",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre42 = new Genre()
                {
                    Name = "Cults",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre43 = new Genre()
                {
                    Name = "Mythology",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre44 = new Genre()
                {
                    Name = "Middle Grade",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre45 = new Genre()
                {
                    Name = "Greek Mythology",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre46 = new Genre()
                {
                    Name = "Urban Fantasy",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre47 = new Genre()
                {
                    Name = "British Literature",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre48 = new Genre()
                {
                    Name = "Victorian",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre49 = new Genre()
                {
                    Name = "Novels",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre50 = new Genre()
                {
                    Name = "Science Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre51 = new Genre()
                {
                    Name = "Humor",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre52 = new Genre()
                {
                    Name = "Murder Mystery",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre53 = new Genre()
                {
                    Name = "Suspense",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre54 = new Genre()
                {
                    Name = "Adventure",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre55 = new Genre()
                {
                    Name = "Young Adult Romance",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre56 = new Genre()
                {
                    Name = "Realistic Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre57 = new Genre()
                {
                    Name = "Transgender",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre58 = new Genre()
                {
                    Name = "Retellings",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre59 = new Genre()
                {
                    Name = "Fairy Tales",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre60 = new Genre()
                {
                    Name = "Jewish",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre61 = new Genre()
                {
                    Name = "Standalone",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre62 = new Genre()
                {
                    Name = "Ghosts",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre63 = new Genre()
                {
                    Name = "Fantasy Sci-Fi",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre64 = new Genre()
                {
                    Name = "Cozy Fantasy",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre65 = new Genre()
                {
                    Name = "New Adult",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre66 = new Genre()
                {
                    Name = "Age Adult",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre67 = new Genre()
                {
                    Name = "Historical Mystery",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre68 = new Genre()
                {
                    Name = "Magical Realism",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre69 = new Genre()
                {
                    Name = "Adult Romance",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre70 = new Genre()
                {
                    Name = "Fairy Tale Retelling",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre71 = new Genre()
                {
                    Name = "New York",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre72 = new Genre()
                {
                    Name = "Cultural",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre73 = new Genre()
                {
                    Name = "Religion",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre74 = new Genre()
                {
                    Name = "Judaica",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre75 = new Genre()
                {
                    Name = "Judaism",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre76 = new Genre()
                {
                    Name = "Supernatural",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre77 = new Genre()
                {
                    Name = "Books About Books",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre78 = new Genre()
                {
                    Name = "Speculative Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre79 = new Genre()
                {
                    Name = "Dystopia",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre80 = new Genre()
                {
                    Name = "Young Adult Contemporary",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre81 = new Genre()
                {
                    Name = "Short Stories",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre82 = new Genre()
                {
                    Name = "Anthologies",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre83 = new Genre()
                {
                    Name = "Collections",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre84 = new Genre()
                {
                    Name = "Military Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre85 = new Genre()
                {
                    Name = "War",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre86 = new Genre()
                {
                    Name = "Time Travel",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre87 = new Genre()
                {
                    Name = "Teen",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre88 = new Genre()
                {
                    Name = "Short Story Collection",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre89 = new Genre()
                {
                    Name = "Politics",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre90 = new Genre()
                {
                    Name = "Climate Change Fiction",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre91 = new Genre()
                {
                    Name = "Space Opera",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre92 = new Genre()
                {
                    Name = "Animals",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre93 = new Genre()
                {
                    Name = "Childrens",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre94 = new Genre()
                {
                    Name = "Dogs",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre95 = new Genre()
                {
                    Name = "Juvenile",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre96 = new Genre()
                {
                    Name = "Classics",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre97 = new Genre()
                {
                    Name = "Greece",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre98 = new Genre()
                {
                    Name = "Feminism",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre99 = new Genre()
                {
                    Name = "Alternate History",
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var genre100 = new Genre()
                {
                    Name = "Urban Fantasy",
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
                        genre5,
                        genre6,
                        genre7,
                        genre8,
                        genre9,
                        genre10,
                        genre11,
                        genre12,
                        genre13,
                        genre14,
                        genre15,
                        genre16,
                        genre17,
                        genre18,
                        genre19,
                        genre20,
                        genre21,
                        genre22,
                        genre23,
                        genre24,
                        genre25,
                        genre26,
                        genre27,
                        genre28,
                        genre29,
                        genre30,
                        genre31,
                        genre32,
                        genre33,
                        genre34,
                        genre35,
                        genre36,
                        genre37,
                        genre38,
                        genre39,
                        genre40,
                        genre41,
                        genre42,
                        genre43,
                        genre44,
                        genre45,
                        genre46,
                        genre47,
                        genre48,
                        genre49,
                        genre50,
                        genre51,
                        genre52,
                        genre53,
                        genre54,
                        genre55,
                        genre56,
                        genre57,
                        genre58,
                        genre59,
                        genre60,
                        genre61,
                        genre62,
                        genre63,
                        genre64,
                        genre65,
                        genre66,
                        genre67,
                        genre68,
                        genre69,
                        genre70,
                        genre71,
                        genre72,
                        genre73,
                        genre74,
                        genre75,
                        genre76,
                        genre77,
                        genre78,
                        genre79,
                        genre80,
                        genre81,
                        genre82,
                        genre83,
                        genre84,
                        genre85,
                        genre86,
                        genre87,
                        genre88,
                        genre89,
                        genre90,
                        genre91,
                        genre92,
                        genre93,
                        genre94,
                        genre95,
                        genre96,
                        genre97,
                        genre98,
                        genre99,
                        genre100,

                    });
                    context.SaveChanges();
                }

                // Books
                var book1 = new Book()
                {
                    Author = author1,
                    Title = "The Long Game",
                    Description = "A disgraced soccer exec reluctantly enlists the help of a retired soccer star in coaching a children’s team in this smalltown love story in the vein of Ted Lasso and It Happened One Summer —from the New York Times bestselling author of The Spanish Love Deception.\r\n\r\nAdalyn Reyes has spent years perfecting her daily routine: wake up at dawn, drive to the Miami Flames FC offices, try her hardest to leave a mark, go home, and repeat.\r\n\r\nBut her routine is disrupted when a video of her in an altercation with the team’s mascot goes viral. Rather than fire her, the team’s owner—who happens to be her father—sends Adalyn to middle-of-nowhere North Carolina, where she’s tasked with turning around the struggling local soccer team, the Green Warriors, as a way to redeem herself. Her plans crumble upon discovering that the players wear tutus to practice (impractical), keep pet goats (messy), and are terrified of Adalyn (counterproductive), and are nine-year-old kids.\r\n\r\nTo make things worse, also in town is Cameron Caldani, goalkeeping prodigy whose presence is somewhat of a mystery. Cam is the perfect candidate to help Adalyn, but after one very unfortunate first encounter involving a rooster, Cam’s leg, and Adalyn’s bumper, he’s also set on running her out of town. But banishment is not an option for Adalyn. Not again. Helping this ragtag children’s team is her road to redemption, and she is playing the long game. With or without Cam’s help.",
                    Image = "uploads/images/1.jpg",
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
                var book2 = new Book()
                {
                    Author = author2,
                    Title = "The Unfortunate Side Effects of Heart Break and Magic",
                    Description = "Sadie Revelare has always believed that the curse of four heartbreaks that accompanies her magic would be worth the price. But when her grandmother is diagnosed with cancer with only weeks to live, and her first heartbreak, Jake McNealy, returns to town after a decade, her carefully structured life begins to unravel.\r\n\r\nWith the news of their grandmother's impending death, Sadie's estranged twin brother Seth returns to town, bringing with him deeply buried family secrets that threaten to tear Sadie's world apart. Their grandmother has been the backbone of the family for generations, and with her death, Sadie isn't sure she'll have the strength to keep the family, and her magic, together.\r\n\r\nAs feelings for Jake begin to rekindle, and her grandmother growing sicker by the day, Sadie faces the last of her heartbreaks, and she has to decide: is love more important than magic?.\r\n",
                    Image = "uploads/images/2.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Alcove Press",
                    Isbn = "9781639105731",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 322,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book3 = new Book()
                {
                    Author = author3,
                    Title = "Fall of Ruin and Wrath",
                    Description = "SHE LIVES BY HER INTUITION. HE FEEDS ON HER PLEASURE.\r\n\r\nLong ago, the world was destroyed by gods. Only nine cities were spared. Separated by vast wilderness teeming with monsters and unimaginable dangers, each city is now ruled by a guardian―royalty who feed on mortal pleasure.\r\n\r\nBorn with an intuition that never fails, Calista knows her talents are of great value to the power-hungry of the world, so she lives hidden as a courtesan of the Baron of Archwood. In exchange for his protection, she grants him information.\r\n\r\nWhen her intuition leads her to save a traveling prince in dire trouble, the voice inside her blazes with warning―and promise. Today he’ll bring her joy. One day he'll be her doom.\r\n\r\nWhen the Baron takes an interest in the traveling prince and the prince takes an interest in Calista, she becomes the prince’s temporary companion. But the city simmers with rebellion, and with knights and monsters at her city gates and a hungry prince in her bed, intuition may not be enough to keep her safe.\r\n\r\nCalista must follow her intuition to safety or follow her heart to her downfall.\r\n",
                    Image = "uploads/images/3.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "Bramble",
                    Isbn = "9781250750198",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 432,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book4 = new Book()
                {
                    Author = author4,
                    Title = "You, Again",
                    Description = "A commitment-phobe and a hopeless romantic clash over and over again--until heartbreak and unexpected chemistry bring them together in this clever enemies-to-friends-to-lovers debut romance.\r\n\r\nWhen Ari and Josh first meet, the wrong kind of sparks fly. They hate each other. Instantly.\r\n\r\nA free-spirited, struggling comedian who likes to keep things casual, Ari sublets, takes gigs, and she never sleeps over after hooking up. Born-and-bred Manhattanite Josh has ambitious plans: Take the culinary world by storm, find The One, and make her breakfast in his spotless kitchen. They have absolutely nothing in common . . . except that they happen to be sleeping with the same woman.\r\n\r\nAri and Josh never expect their paths to cross again. But years later, as they're both reeling from ego-bruising breakups, a chance encounter leads to a surprising connection: friendship. Turns out, spending time with your former nemesis is fun when you're too sad to hate each other--and too sad for hate sex.\r\n\r\nAs friends-without-benefits, they find comfort in late-night Netflix binges, swiping through each other's online dating profiles, and bickering across boroughs. It's better than romance. Until one night, the unspoken boundaries of their platonic relationship begin to blur. . . .\r\n\r\nWith sharp observations and sizzling chemistry, You, Again explores the dynamics of co-ed friendship in this sparkling romantic comedy of modern love in all its forms.\r\n",
                    Image = "uploads/images/4.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "Random House Publishing Group",
                    Isbn = "9780593448120",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 448,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book5 = new Book()
                {
                    Author = author5,
                    Title = "The Wake-Up Call",
                    Description = "Two hotel receptionists--and arch-rivals--find a collection of old wedding rings and compete to return them to their owners, discovering their own love story along the way.\r\n\r\nIt's the busiest season of the year, and Forest Manor Hotel is quite literally falling apart. So when Izzy and Lucas are given the same shift on the hotel's front desk, they have no choice but to put their differences aside and see it through.\r\n\r\nThe hotel won't stay afloat beyond Christmas without some sort of miracle. But when Izzy returns a guest's lost wedding ring, the reward convinces management that this might be the way to fix everything. With four rings still sitting in the lost & found, the race is on for Izzy and Lucas to save their beloved hotel--and their jobs.\r\n\r\nAs their bitter rivalry turns into something much more complicated, Izzy and Lucas begin to wonder if there's more at stake here than the hotel's future. Can the two of them make it through the season with their hearts intact?\r\n",
                    Image = "uploads/images/5.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Berkley",
                    Isbn = "9780593640128",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 368,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book6 = new Book()
                {
                    Author = author6,
                    Title = "Cleat Cute",
                    Description = "A sapphic rivals to lovers rom com for fans of Ted Lasso and A League of Their Own, where two soccer teammates are at odds before falling in love as their team gears up for the World Cup.\r\n\r\nGrace Henderson has been a star of the US Women’s National Team for ten years, even though she’s only 26. But when she’s sidelined with an injury, a bold new upstart, Phoebe Matthews, takes her spot. Phoebe is everything Grace isn’t—a gregarious jokester who plays with a joy that Grace lost somewhere along the way. The last thing Grace expects is to become friends with benefits with this class clown she sees as her rival.\r\n\r\nPhoebe Matthews has always admired Grace’s skill and was star struck to be training alongside her idol. But she quickly finds herself looking at Grace as more than a mere teammate. After one daring kiss, she’s hooked. Grace is everything she has been waiting to find.\r\n\r\nAs the World Cup approaches, and Grace works her way back from injury, the women decide to find a way they can play together instead of vying for the same position. Except, when they are off the field, Grace is worried she’s catching feelings while Phoebe thinks they are dating. As the tension between them grows, will both players realize they care more about their relationship than making the roster?",
                    Image = "uploads/images/6.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Griffin",
                    Isbn = "9781250873309",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 336,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book7 = new Book()
                {
                    Author = author7,
                    Title = "Nineteen Steps",
                    Description = "It’s 1942, and air raid sirens continue to wail around London. Eighteen-year-old Nellie Morris counts every day lucky that she emerges from the underground shelters unharmed, her loving family still surrounding her.\r\n\r\nAfter a chance encounter with Ray, an American airman stationed nearby, Nellie becomes enchanted with the idea of a broader world. Just when Nellie begins to embrace an exciting new life with Ray, a terrible incident occurs during an air raid one evening, tearing Nellie’s world is torn apart. But just when it seems all hope is lost, Nellie finds that, against all odds, love and happiness can triumph.\r\n\r\nNineteen Steps is a deeply affecting, mesmerizing page-turner inspired by the author’s family history. An epic story of longing, loss, and secrets, Millie Bobby Brown’s propulsive debut introduces an unforgettable, brave young woman and boldly portrays the strength in the power of love.",
                    Image = "uploads/images/7.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "William Morrow",
                    Isbn = "9780063335783",
                    Language = "English",
                    Format = "Ebook",
                    Pages = 320,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book8 = new Book()
                {
                    Author = author8,
                    Title = "Foul Hearts Huntsman",
                    Description = "Winter is drawing thick in 1932 Shanghai, as is the ever-nearing threat of a Japanese invasion.\r\n\r\nRosalind Lang has suffered the worst possible fate for a national spy: she’s been exposed. With the media storm camped outside her apartment for the infamous Lady Fortune, she’s barely left her bedroom in weeks, plotting her next course of action after Orion was taken and his memories of Rosalind wiped. Though their marriage might have been a sham, his absence hurts her more than any physical wound. She won’t rest until she gets him back.\r\n\r\nBut with her identity in the open, the task is near impossible. The only way to leave the city and rescue Orion is under the guise of a national tour. It’s easy to convince her superiors that the countryside needs unity more than ever, and who better than an immortal girl to stir pride and strength into the people?\r\n\r\nWhen the tour goes wrong, however, everything Rosalind once knew is thrown up in the air. Taking refuge outside Shanghai, old ghosts come into the open and adversaries turn to allies. To save Orion, they must find a cure to his mother’s traitorous invention and take this dangerous chemical weapon away from impending foreign invasion—but the clock is ticking, and if Rosalind fails, it’s not only Orion she loses, but her nation itself.\r\n",
                    Image = "uploads/images/8.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Margaret K. McElderry Books",
                    Isbn = "9781665905619",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 560,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book9 = new Book()
                {
                    Author = author9,
                    Title = "The Scarlet Veil",
                    Description = "Célie Tremblay has always been a good girl: kind and beautiful, a daughter of whom every parent would be proud. She surprises the entire kingdom when she defies tradition to become the first huntswoman—including her new captain and fiancé, Jean Luc, who rules the huntsmen with an iron fist. He isn’t the only one concerned for Célie’s safety, however. Though her friends try to protect her from the horrors of her past, mysterious whispers still haunt her, and a new evil is rising in Belterra—leaving bodies in its wake, each one drained of blood.\r\n\r\nDetermined to prove herself in her new role, Célie tracks the killer to the lair of Les Éternels—ancient creatures only spoken about in nursery rhymes—and catches the attention of their king, a monster who hides his plans for her behind beautiful words and sharp smiles. Now Célie has new reason to fear the dark because the closer he gets, the more tempted she feels to give in to his dark hunger—and her own.\r\n",
                    Image = "uploads/images/9.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "HarperTeen",
                    Isbn = "9780063258754",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 640,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book10 = new Book()
                {
                    Author = author10,
                    Title = "Enchanted to Meet You",
                    Description = "It’s Magic When You Meet Your Match In her teenage years, lovelorn Jessica Gold cast a spell that went disastrously wrong, and brought her all the wrong kind of attention—as well as a lifetime ban from the World Council of Witches.\r\n\r\nSo no one is more surprised than Jess when, fifteen years later, tall, handsome WCW member Derrick Winters shows up in her quaint little village of West Harbor and claims that Jess is the Chosen One.\r\n\r\nShe’s the Chosen One Not chosen by West Harbor’s snobby elite to style them for the town’s tricentennial ball—though Jess owns the chicest clothing boutique in town. And not chosen finally to be on the WCW, either—not that Jess would have said yes, anyway, since she’s done with any organization that tries to dictate what makes a “true” witch. No, Jess has been chosen to help save West Harbor itself...\r\n\r\nAs Summer Ends, Her Power Grows But just when Jess is beginning to think that she and Derrick might have a certain magic of their own—and not of the supernatural variety—Jess learns he may not be who she thought he was. And suddenly Jess finds herself having to trust Derrick and work with him to combat the sinister force battling to bring down West Harbor, or use her gift as she always to keep herself, and her heart, safe. Can she work her magic in time?\r\n",
                    Image = "uploads/images/10.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Avon",
                    Isbn = "9780063268371",
                    Language = "English",
                    Format = "ebook",
                    Pages = 368,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book11 = new Book()
                {
                    Author = author11,
                    Title = "The Fragile Threads of Power",
                    Description = "Once, there were four worlds, nestled like pages in a book, each pulsing with fantastical power, and connected by a single city: London. Until the magic grew too fast, and forced the worlds to seal the doors between them in a desperate gamble to protect their own. The few magicians who could still open the doors grew more rare as time passed and now, only three Antari are known in recent memory―Kell Maresh of Red London, Delilah Bard of Grey London, and Holland Vosijk, of White London.\r\n\r\nBut barely a glimpse of them have been seen in the last seven years―and a new Antari named Kosika has appeared in White London, taking the throne in Holland's absence. The young queen is willing to feed her city with blood, including her own―but her growing religious fervor has the potential to drown them instead.\r\n\r\nAnd back in Red London, King Rhy Maresh is threatened by a rising rebellion, one determined to correct the balance of power by razing the throne entirely.\r\n\r\nAmidst this tapestry of old friends and new enemies, a girl with an unusual magical ability comes into possession of a device that could change the fate of all four worlds.\r\n\r\nHer name is Tes, and she's the only one who can bring them together―or unravel it all.\r\n",
                    Image = "uploads/images/11.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Tor Books",
                    Isbn = "9780765387493",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 648,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book12 = new Book()
                {
                    Author = author12,
                    Title = "Bright Young Women",
                    Description = "January 1978. A serial killer has terrorized women across the Pacific Northwest, but his existence couldn’t be further from the minds of the vibrant young women at the top sorority on Florida State University’s campus in Tallahassee. Tonight is a night of promise, excitement, and desire, but Pamela Schumacher, president of the sorority, makes the unpopular decision to stay home—a decision that unwittingly saves her life. Startled awake at 3 a.m. by a strange sound, she makes the fateful decision to investigate. What she finds behind the door is a scene of implausible violence—two of her sisters dead; two others, maimed. Over the next few days, Pamela is thrust into a terrifying mystery inspired by the crime that’s captivated public interest for more than four decades.\r\n\r\nOn the other side of the country, Tina Cannon has found peace in Seattle after years of hardship. A chance encounter brings twenty-five-year-old Ruth Wachowsky into her life, a young woman with painful secrets of her own, and the two form an instant connection. When Ruth goes missing from Lake Sammamish State Park in broad daylight, surrounded by thousands of beachgoers on a beautiful summer day, Tina devotes herself to finding out what happened to her. When she hears about the tragedy in Tallahassee, she knows it’s the man the papers refer to as the All-American Sex Killer. Determined to make him answer for what he did to Ruth, she travels to Florida on a collision course with Pamela—and one last impending tragedy.\r\n\r\nBright Young Women is the story about two women from opposite sides of the country who become sisters in their fervent pursuit of the truth. It proposes a new narrative inspired by evidence that’s been glossed over for decades in favor of more salable headlines—that the so-called brilliant and charismatic serial killer from Seattle was far more average than the countless books, movies, and primetime specials have led us to believe, and that it was the women whose lives he cut short who were the exceptional ones.\r\n",
                    Image = "uploads/images/12.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "S&S/Marysue Rucci Books",
                    Isbn = "9781501153228",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 384,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book13 = new Book()
                {
                    Author = author13,
                    Title = "The Last Devil to Die",
                    Description = "Shocking news reaches the Thursday Murder Club.\r\n\r\nAn old friend in the antiques business has been killed, and a dangerous package he was protecting has gone missing.\r\n\r\nAs the gang springs into action they encounter art forgers, online fraudsters and drug dealers, as well as heartache close to home.\r\n\r\nWith the body count rising, the package still missing and trouble firmly on their tail, has their luck finally run out? And who will be the last devil to die?\r\n",
                    Image = "uploads/images/13.jpg",
                    PublishDate = new DateTime(2023, 9, 14),
                    Publisher = "Viking",
                    Isbn = "9780241512449",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 422,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book14 = new Book()
                {
                    Author = author14,
                    Title = "Rouge",
                    Description = "For as long as she can remember, Belle has been insidiously obsessed with her skin and skincare videos. When her estranged mother Noelle mysteriously dies, Belle finds herself back in Southern California, dealing with her mother’s considerable debts and grappling with lingering questions about her death. The stakes escalate when a strange woman in red appears at the funeral, offering a tantalizing clue about her mother’s demise, followed by a cryptic video about a transformative spa experience. With the help of a pair of red shoes, Belle is lured into the barbed embrace of La Maison de Méduse, the same lavish, culty spa to which her mother was devoted. There, Belle discovers the frightening secret behind her (and her mother’s) obsession with the mirror—and the great shimmering depths (and demons) that lurk on the other side of the glass.\r\n\r\nSnow White meets Eyes Wide Shut in this surreal descent into the dark side of beauty, envy, grief, and the complicated love between mothers and daughters. With black humor and seductive horror, Rouge explores the cult-like nature of the beauty industry—as well as the danger of internalizing its pitiless gaze. Brimming with California sunshine and blood-red rose petals, Rouge holds up a warped mirror to our relationship with mortality, our collective fixation with the surface, and the wondrous, deep longing that might lie beneath.\r\n",
                    Image = "uploads/images/14.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "S&S/Marysue Rucci Books",
                    Isbn = "9781982169695",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 384,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book15 = new Book()
                {
                    Author = author15,
                    Title = "Evil Eye",
                    Description = "Raised in a conservative and emotionally volatile Palestinian family in Brooklyn, Yara thought she would finally feel free when she married a charming entrepreneur who took her to the suburbs. She’s gotten to follow her dreams, completing an undergraduate degree in Art and landing a good job at the local college. As a traditional wife, she also raises their two school-aged daughters, takes care of the house, and has dinner ready when her husband gets home. With her family balanced with her professional ambitions, Yara knows that her life is infinitely more rewarding than her own mother’s. So why doesn’t it feel like enough?\r\n\r\nAfter her dream of chaperoning a student trip to Europe evaporates and she responds to a colleague’s racist provocation, Yara is put on probation at work and must attend mandatory counseling to keep her position. Her mother blames a family curse for the trouble she’s facing, and while Yara doesn’t really believe in old superstitions, she still finds herself growing increasingly uneasy with her mother’s warning and the possibility of falling victim to the same mistakes.\r\n\r\nShaken to the core by these indictments of her life, Yara finds her carefully constructed world beginning to implode. To save herself, Yara must reckon with the reality that the difficulties of the childhood she thought she left behind have very real—and damaging—implications not just on her own future but that of her daughters.\r\n",
                    Image = "uploads/images/15.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Harper",
                    Isbn = "9780062987907",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 352,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book16 = new Book()
                {
                    Author = author16,
                    Title = "The Vaster Wilds",
                    Description = "A taut and electrifying novel from celebrated bestselling author Lauren Groff, about one spirited girl alone in the wilderness, trying to survive\r\n\r\nA servant girl escapes from a colonial settlement in the wilderness. She carries nothing with her but her wits, a few possessions, and the spark of god that burns hot within her. What she finds in this terra incognita is beyond the limits of her imagination and will bend her belief in everything that her own civilization has taught her.\r\n\r\nLauren Groff’s new novel is at once a thrilling adventure story and a penetrating fable about trying to find a new way of living in a world succumbing to the churn of colonialism. The Vaster Wilds is a work of raw and prophetic power that tells the story of America in miniature, through one girl at a hinge point in history, to ask how—and if—we can adapt quickly enough to save ourselves.\r\n",
                    Image = "uploads/images/16.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "Riverhead Books",
                    Isbn = "9780593418390",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 272,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book17 = new Book()
                {
                    Author = author17,
                    Title = "Black Sheep",
                    Description = "A cynical twentysomething must confront her unconventional family’s dark secrets in this fiery, irreverent horror novel from the author of Such Sharp Teeth and Cackle.\r\n\r\nNobody has a “normal” family, but Vesper Wright’s is truly...something else. Vesper left home at eighteen and never looked back—mostly because she was told that leaving the staunchly religious community she grew up in meant she couldn’t return. But then an envelope arrives on her doorstep.\r\n\r\nInside is an invitation to the wedding of Vesper’s beloved cousin Rosie. It’s to be hosted at the family farm. Have they made an exception to the rule? It wouldn’t be the first time Vesper’s been given special treatment. Is the invite a sweet gesture? An olive branch? A trap? Doesn’t matter. Something inside her insists she go to the wedding. Even if it means returning to the toxic environment she escaped. Even if it means reuniting with her mother, Constance, a former horror film star and forever ice queen.\r\n\r\nWhen Vesper’s homecoming exhumes a terrifying secret, she’s forced to reckon with her family’s beliefs and her own crisis of faith in this deliciously sinister novel that explores the way family ties can bind us as we struggle to find our place in the world.\r\n",
                    Image = "uploads/images/17.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Berkley",
                    Isbn = "9780593545850",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 289,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book18 = new Book()
                {
                    Author = author18,
                    Title = "The Chalice of the Gods",
                    Description = "After saving the world multiple times, Percy Jackson is hoping to have a normal senior year. Unfortunately, the gods aren’t quite done with him. Percy will have to fulfill three quests in order to get the necessary three letters of recommendation from Mount Olympus for college.\r\n\r\nThe first quest is to help Zeus’s cup-bearer retrieve his goblet before it falls into the wrong hands. Can Percy, Grover, and Annabeth find it in time?\r\n\r\nReaders new to Percy Jackson and fans who have been awaiting this reunion for more than a decade will delight equally in this latest hilarious take on Greek mythology.\r\n",
                    Image = "uploads/images/18.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Disney Hyperion",
                    Isbn = "9781368098175",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 288,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book19 = new Book()
                {
                    Author = author19,
                    Title = "The Fraud",
                    Description = "It is 1873. Mrs Eliza Touchet is the Scottish housekeeper - and cousin by marriage - of a once famous novelist, now in decline, William Ainsworth, with whom she has lived for thirty years.\r\n\r\nMrs Touchet is a woman of many interests: literature, justice, abolitionism, class, her cousin, his wives, this life and the next. But she is also sceptical. She suspects her cousin of having no talent; his successful friend, Mr Charles Dickens, of being a bully and a moralist; and England of being a land of facades, in which nothing is quite what it seems.\r\n\r\nAndrew Bogle meanwhile grew up enslaved on the Hope Plantation, Jamaica. He knows every lump of sugar comes at a human cost. That the rich deceive the poor. And that people are more easily manipulated than they realise. When Bogle finds himself in London, star witness in a celebrated case of imposture, he knows his future depends on telling the right story.\r\n\r\nThe 'Tichborne Trial' captivates Mrs Touchet and all of England. Is Sir Roger Tichborne really who he says he is? Or is he a fraud? Mrs Touchet is a woman of the world. Mr Bogle is no fool. But in a world of hypocrisy and self-deception, deciding what is real proves a complicated task...\r\n\r\nBased on real historical events, The Fraud is a dazzling novel about truth and fiction, Jamaica and Britain, fraudulence and authenticity, and the mystery of 'other people.\r\n",
                    Image = "uploads/images/19.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Penguin Press",
                    Isbn = "9780525558965",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 464,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book20 = new Book()
                {
                    Author = author20,
                    Title = "Starter Villain",
                    Description = "Charlie's life is going nowhere fast. A divorced substitute teacher living with his cat in a house his siblings want to sell, all he wants is to open a pub downtown, if only the bank will approve his loan.\r\n\r\nThen his long-lost uncle Jake dies and leaves his supervillain business (complete with island volcano lair) to Charlie.\r\n\r\nBut becoming a supervillain isn't all giant laser death rays and lava pits. Jake had enemies, and now they're coming after Charlie. His uncle might have been a stand-up, old-fashioned kind of villain, but these are the real thing: rich, soulless predators backed by multinational corporations and venture capital.\r\n\r\nIt's up to Charlie to win the war his uncle started against a league of supervillains. But with unionized dolphins, hyperintelligent talking spy cats, and a terrifying henchperson at his side, going bad is starting to look pretty good.\r\n\r\nIn a dog-eat-dog world...be a cat.\r\n",
                    Image = "uploads/images/20.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Tor Books",
                    Isbn = "9780765389220",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 264,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book21 = new Book()
                {
                    Author = author21,
                    Title = "Suddenly a Murder",
                    Description = "Someone brought a knife to the party.\r\n\r\nTo celebrate the end of high school, Izzy Morales joins her ride-or-die Kassidy and five friends on a 1920s-themed getaway at the glamorous Ashwood Manor. There, Izzy and her friends party in vintage dresses and expensive diamonds--until Kassidy's boyfriend turns up dead.\r\n\r\nMurdered, investigators declare when they arrive at the scene, and now every party guest is a suspect. There's the girlfriend, in love. The other girl, in despair. The old friend, forlorn. The new friend, distressed. The brooding enigma. And then, there's Izzy--the girl who brought the knife.\r\n\r\nTo find the killer, everyone must undergo a grueling interrogation, all while locked in an estate where, suddenly, the greatest luxury is innocence.\r\n",
                    Image = "uploads/images/21.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "G.P. Putnam's Sons Books for Young Readers",
                    Isbn = "9780593617533",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 320,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book22 = new Book()
                {
                    Author = author22,
                    Title = "Thieves' Gambit",
                    Description = "At only seventeen years old, Ross Quest is already a master thief, especially adept at escape plans. Until her plan to run away from her legendary family of thieves takes an unexpected turn, leaving her mother's life hanging in the balance.\r\n\r\nIn a desperate bid, she enters the Thieves' Gambit, a series of dangerous, international heists where killing the competition isn't exactly off limits, but the grand prize is a wish for anything in the world--a wish that could save her mom. When she learns two of her competitors include her childhood nemesis and a handsome, smooth-talking guy who might also want to steal her heart, winning the Gambit becomes trickier than she imagined.\r\n\r\nRoss tries her best to stick to the family creed: trust no one whose last name isn't Quest. But with the stakes this high, Ross will have to decide who to con and who to trust before time runs out. After all, only one of them can win.\r\n",
                    Image = "uploads/images/22.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Nancy Paulsen Books",
                    Isbn = "9780593625361",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 384,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book23 = new Book()
                {
                    Author = author23,
                    Title = "The Name Drop",
                    Description = "When Elijah Ri arrives in New York City for an internship at his father’s massive tech company, Haneul Corporation, he expects the royal treatment that comes with being the future CEO—even if that’s the last thing he wants. But instead, he finds himself shuffled into a group of overworked, unpaid interns, all sharing a shoebox apartment for the summer.\r\n\r\nWhen Jessica Lee arrives in New York City, she’s eager to make the most of her internship at Haneul Corporation, even if she’s at the bottom of the corporate ladder. But she’s shocked to be introduced as the new executive-in-training intern with a gorgeous brownstone all to herself.\r\n\r\nIt doesn’t take long for Elijah and Jessica to discover the source of the they share the same Korean name. But they decide to stay switched—so Elijah can have a relaxing summer away from his controlling dad while Jessica can make the connections she desperately needs for college recommendations.\r\n\r\nAs Elijah and Jessica work together to keep up the charade, a spark develops between them. Can they avoid discovery—and total disaster—with their feelings and futures on the line?\r\n",
                    Image = "uploads/images/23.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "Inkyard Press",
                    Isbn = "9781335457981",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 304,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book24 = new Book()
                {
                    Author = author24,
                    Title = "The Only Girl in Town",
                    Description = "An eerily beautiful and lyrical story of loss, grief, and how quickly relationships can change, while also changing us.” —Robin Benway, National Book Award winner and bestselling author of Far From The Tree and A Year to the Day\r\n\r\n“Fast-paced, unputdownable, and full of heart and complicated emotions. An unforgettable story.” —Yamile Saied Méndez, Pura Belpré Award–winning author of Furia , a Reese’s Book Club selection\r\n\r\nWhat would you do if everyone you love disappeared? What if it was your fault?\r\n\r\nFor July Fielding, nothing has been the same since that summer before senior year.\r\n\r\nOnce, she had Alex, her loyal best friend, the one who always had her back. She had Sydney, who pushed her during every cross-country run, and who sometimes seemed to know July better than she knew herself. And she had Sam. Sam, who told her she was everything and left her breathless with his touch.\r\n\r\nNow, July is alone. Every single person in her small town of Lithia has disappeared. No family. No Alex or Sydney. No Sam. July’s only chance at unraveling the mystery of their disappearance is a series of objects, each a reminder of the people she loved most. And a mysterious GET TH3M BACK.\r\n\r\nFrom the #1 bestselling author of the Matched series, The Only Girl in Town is a searingly candid reckoning with both love and loneliness that perfectly distills the messy, beautiful realities of growing up, growing apart, and the courageous act of self-discovery.\r\n",
                    Image = "uploads/images/24.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Dutton Books for Young Readers",
                    Isbn = "9780593327173",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 336,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book25 = new Book()
                {
                    Author = author25,
                    Title = "The Spirit Bares Its Teeth",
                    Description = "Mors vincit omnia. Death conquers all.\r\n\r\nLondon, 1883. The Veil between the living and dead has thinned. Violet-eyed mediums commune with spirits under the watchful eye of the Royal Speaker Society, and sixteen-year-old Silas Bell would rather rip out his violet eyes than become an obedient Speaker wife. According to Mother, he’ll be married by the end of the year. It doesn’t matter that he’s needed a decade of tutors to hide his autism; that he practices surgery on slaughtered pigs; that he is a boy, not the girl the world insists on seeing.\r\n\r\nAfter a failed attempt to escape an arranged marriage, Silas is diagnosed with Veil sickness—a mysterious disease sending violet-eyed women into madness—and shipped away to Braxton’s Sanitorium and Finishing School. The facility is cold, the instructors merciless, and the students either bloom into eligible wives or disappear. So when the ghosts of missing students start begging Silas for help, he decides to reach into Braxton’s innards and expose its rotten guts to the world—as long as the school doesn’t break him first.\r\n",
                    Image = "uploads/images/25.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Peachtree Teen",
                    Isbn = "9781682636183",
                    Language = "English",
                    Format = "Kindle Edition",
                    Pages = 384,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book26 = new Book()
                {
                    Author = author26,
                    Title = "The Forest Grimm",
                    Description = "Where fairy tales come to life with dark, deadly twists...\r\n\r\n\"Tell me again, Grandmère, the story of how I die.\"\r\n\r\nThe Midnight Forest. The Fanged Creature. Two fortune-telling cards that spell an untimely death for 17-year-old Clara. Despite the ever-present warning from her fortune-teller grandmother, Clara embarks on a dangerous journey into the deadly Forest Grimm to procure a magical book - Sortes Fortunae , the Book of Fortunes - with the power to reverse the curse on her village and save her mother.\r\n\r\nYears ago, when the villagers whispered their deepest desires to the book, its pages revealed how to obtain them. All was well until someone used the book for an evil purpose―to kill another person. Afterward, the branches of the Forest Grimm snatched the book away, the well water in Grimm’s Hollow turned rancid, and the crops died from disease. The villagers tried to make amends with the forest, but every time someone crossed its border, they never returned.\r\n\r\nNow, left with no alternative, Clara and her close friend, Axel―who is fated never to be with her―have set their minds to defying fate and daring to accomplish what no one else has been able to before. But the forest―alive with dark, deadly twists on some of our most well-known fairy tales―has a mind of its own.\r\n",
                    Image = "uploads/images/26.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Wednesday Books",
                    Isbn = "9781250873002",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 352,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book27 = new Book()
                {
                    Author = author27,
                    Title = "This Dark Descent",
                    Description = "The Shadows Between Us meets Six of Crows in this spellbinding new fantasy full of intrigue, romance, and pulse-pounding action, where the eldest daughter of a renowned family on the verge of ruin joins forces with a mysterious, rogue enchanter and a handsome, ambitious heir to win a deadly race.\r\n\r\nMikira Rusel’s family has long been famous for breeding enchanted horses, but their prestige is no match for their rising debts. To save her ranch, Mikira has only one option: she must win the Illinir, a treacherous horserace whose riders either finish maimed or murdered. Yet each year, competitors return, tempted by its alluring prize money and unparalleled prestige.\r\n\r\nMikira’s mission soon unites her with Arielle Kadar, an impressive yet illicit enchanter just beginning to come into her true power, and Damien Adair, a dashing young lord in the midst of a fierce succession battle. Both have hidden reasons of their own to help Mikira -- as well as their own blood feuds to avenge…\r\n\r\nSteeped in Jewish folklore, This Dark Descent is a pulse-pounding new fantasy full of forbidden magic, sizzling romance, and epic stakes. In a world as dangerous as this, will the need for vengeance butcher Mikira’s chances of winning the Illinir … or will another rider’s dagger?\r\n",
                    Image = "uploads/images/27.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Roaring Brook Press",
                    Isbn = "9781250812360",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 400,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book28 = new Book()
                {
                    Author = author28,
                    Title = "There’s No Way I’d Die First",
                    Description = "Debut author Lisa Springer delivers a spine-tingling contemporary horror that follows a scary-movie buff as she hosts an elaborate Halloween bash on her family's estate but soon finds the festivities upended when she and her guests are forced to test their survival skills in a deadly party game.\r\n\r\nNoelle Layne knows horror. Every trope, every warning sign, every survival tactic. She even leads a successful movie club dedicated to the genre. Thus, who better to throw the ultimate, most exclusive Halloween party on all of Long Island? And with the guest list including the coolest kids in her senior class, her popularity is bound to spike. Hopefully, enough to warrant an expansion into podcasting. Plus, the fact that attractive, singer-songwriter Archer Mitchell is coming is honestly the candy corn on top. Nothing is going to kill her party vibes.\r\n\r\nExcept...maybe the low-budget It clown she hires to lead a classic round of tag. He's supposed to be terrifying, though in a comforting, nostalgic way. Instead, the guy is giving major creeps. But maybe Noelle's just that good at hosting? Her confidence is immediately rocked when the night's entertainment axes one of her guests. And he's not done yet. If an evil, murderous clown thinks life is a game, then Noelle is ready to play. She's been waiting a long time to prove that she's a Final Girl.\r\n",
                    Image = "uploads/images/28.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Delacorte Press",
                    Isbn = "9780593643174",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 304,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book29 = new Book()
                {
                    Author = author29,
                    Title = "If I Have to Be Haunted",
                    Description = "Cemetery Boys meets Legendborn in this thrillingly romantic, irresistibly fun YA contemporary fantasy debut following a teenage Chinese American ghost speaker who (reluctantly) makes a deal to raise her nemesis from the dead.\r\n\r\nCara Tang doesn’t want to be haunted.\r\n\r\nLook, the dead have issues, and Cara has enough of her own. Her overbearing mother insists she be the “perfect” Chinese American daughter—which means suppressing her ghost-speaking powers—and she keeps getting into fights with Zacharias Coleson, the local golden boy whose smirk makes her want to set things on fire.\r\n\r\nThen she stumbles across Zach’s dead body in the woods. He’s even more infuriating as a ghost, but Cara’s the only one who can see him—and save him.\r\n\r\nAgreeing to resurrect him puts her at odds with her mother, draws her into a dangerous liminal world of monsters and magic—and worse, leaves her stuck with Zach. Yet as she and Zach grow closer, forced to depend on each other to survive, Cara finds the most terrifying thing is that she might not hate him so much after all.\r\n\r\nMaybe this is why her mother warned her about ghosts.\r\n\r\nDelightful and compulsively readable, this contemporary fantasy has something for every reader: a snarky voice, a magnetic enemies-to-lovers romance, and a spirited adventure through a magical, unpredictable world hidden within our own.\r\n",
                    Image = "uploads/images/29.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "HarperTeen",
                    Isbn = "9780063252769",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 368,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book30 = new Book()
                {
                    Author = author30,
                    Title = "Champion of Fate",
                    Description = "Behind every great hero is an Aristene.\r\n\r\nAristene are mythical female warriors, part of a legendary order. Though heroes might be immortalized in stories, it’s the Aristene who guide them to victory. They are the Heromakers.\r\n\r\nEver since she was an orphan taken in by the order, Reed has wanted to be an Aristene. Now, as an initiate, just one challenge stands in her way: she must shepherd her first hero to glory on the battlefield. Succeed, and Reed will take her place beside her sisters. Fail, and she’ll be cast from the only home she’s ever known.\r\n\r\nNothing is going to stop Reed--until she meets her hero. Hestion is fiery and infuriating, but what begins as an alliance becomes more, and as secrets of the order come to light Reed begins to understand what becoming an Aristene may truly cost. Battle looming, she must choose: the order and the life she had planned, or Hestion, and the one she never expected.\r\n",
                    Image = "uploads/images/30.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Quill Tree Books",
                    Isbn = "9780062977205",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 480,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book31 = new Book()
                {
                    Author = author31,
                    Title = "Assistant to the Villain",
                    Description = "Once Upon a Time meets The Office in Hannah Maehrer’s laugh-out-loud viral TikTok series turned novel, about the sunshine assistant to an Evil Villain…and their unexpected romance.\r\n\r\nASSISTANT WANTED: Notorious, high-ranking villain seeks loyal, levelheaded assistant for unspecified office duties, supporting staff for random mayhem, terror, and other Dark Things In General. Discretion a must. Excellent benefits.\r\n\r\nWith ailing family to support, Evie Sage's employment status isn't just important, it's vital. So when a mishap with Rennedawn’s most infamous Villain results in a job offer—naturally, she says yes. No job is perfect, of course, but even less so when you develop a teeny crush on your terrifying, temperamental, and undeniably hot boss. Don’t find evil so attractive, Evie.\r\n\r\nBut just when she’s getting used to severed heads suspended from the ceiling and the odd squish of an errant eyeball beneath her heel, Evie suspects this dungeon has a huge rat…and not just the literal kind. Because something rotten is growing in the kingdom of Rennedawn, and someone wants to take the Villain—and his entire nefarious empire—out.\r\n\r\nNow Evie must not only resist drooling over her boss but also figure out exactly who is sabotaging his work…and ensure he makes them pay.\r\n\r\nAfter all, a good job is hard to find.\r\n",
                    Image = "uploads/images/31.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Entangled Publishing: Red Tower Books",
                    Isbn = "9781649375803",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 352,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book32 = new Book()
                {
                    Author = author32,
                    Title = "A Queen of Thieves and Chaos",
                    Description = "You betrayed your brother to steal a broken crown.\"\r\n\r\nThe kingdom stands on the brink of chaos. Atticus' grip on the realm is faltering, and as threats arise ever closer to home he is driven to increasingly desperate acts to hold onto power.\r\n\r\nWith Islor's fate now in the balance, Zander stands to defend the Rift from the oncoming Ybarisan army. With the king's forces scattered, he must risk unlikely new alliances.\r\n\r\nAnd behind the walls of Ulysede, secrets wait for its new queen. Romeria knows that the paths of the hidden city will lead her to answers. But will they be enough to save the realm – or is their fate already sealed?\r\n",
                    Image = "uploads/images/32.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "K.A. Tucker",
                    Isbn = "9781990105296",
                    Language = "English",
                    Format = "Kindle Edition",
                    Pages = 606,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book33 = new Book()
                {
                    Author = author33,
                    Title = "The Pomegranate Gate",
                    Description = "Toba Peres can speak, but not shout; she can walk, but not run. She can write with both hands, in different languages, but has not had a formal education. The only treasure Toba has dared to keep is a precious star sapphire, set in a necklace she must never take off.\r\n\r\nNaftaly Cresques sees things that aren’t real, and dreams things that are. He is a well-trained tailor, but a middling one, and he is risking his life to smuggle a strange family heirloom: a centuries-old book he must never read, and must never lose.\r\n\r\nThe Queen of the Sefarad has ordered all Jews to convert, or be exiled with nothing. Toba, Naftaly, and thousands of others are forced to flee their homes. Toba, accidentally separated from their caravan of refugees, stumbles through a strange pomegranate grove into the magical realm of the Maziks: mythical, terrible beings with immense power. There, she discovers latent abilities that put her in the crosshairs of bloodthirsty immortals, but may be key to her survival. On the other side of the gate, Naftaly, intent on rescuing Toba, finds his new companions harbor dangerous secrets of their own.\r\n\r\nNow, hunted by an Inquisition in both worlds, Toba and Naftaly must unravel ancient histories and ancient magics in order to understand the link between the two realms. More than their own lives might be at stake.\r\n\r\nBrimming with folkloric wonder, The Pomegranate Gate weaves history, myth, and magic into an exquisite tale of fate, legacy, and friendship that will leave readers spellbound.\r\n",
                    Image = "uploads/images/33.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Erewhon Books",
                    Isbn = "9781645660576",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 560,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book34 = new Book()
                {
                    Author = author34,
                    Title = "The Square of Sevens",
                    Description = "An orphaned fortune teller in 18th-century England searches for answers about her long-dead mother and uncovers shocking secrets in this immersive and atmospheric saga perfect for fans of Sarah Waters and Sarah Perry.\r\n\r\nCornwall, 1730: A young girl known only as Red travels with her father making a living predicting fortunes using the ancient Cornish method of the Square of Sevens. Shortly before he dies, her father entrusts Red’s care to a gentleman scholar, along with a document containing the secret of the Square of Sevens technique.\r\n\r\nRaised as a lady amidst the Georgian splendor of Bath, Red’s fortune-telling delights in high society. But she cannot ignore the questions that gnaw at her soul: who was her mother? How did she die? And who are the mysterious enemies her father was always terrified would find him?\r\n\r\nThe pursuit of these mysteries takes her from Cornwall and Bath to London and Devon, from the rough ribaldry of the Bartholomew Fair to the grand houses of two of the most powerful families in England. And while Red’s quest brings her the possibility of great reward, it also leads to grave danger.\r\n\r\nLaura Shepherd-Robinson, “the queen of modern Georgian literature” (Susan Stokes-Chapman, author of Pandora), has written a dazzling and Dickensian story of mystery and intrigue, with audacious twists and turns.\r\n",
                    Image = "uploads/images/34.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Atria Books",
                    Isbn = "9781668031124",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 528,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book35 = new Book()
                {
                    Author = author35,
                    Title = "What Became of Magic",
                    Description = "From Paige Crutcher, the author of The Orphan Witch and The Lost Witch , comes a new tale about a witch, a book of magic, and a beguiling and powerful creature whom she must free, even if it puts her life and soul at stake.\r\n\r\nAline Weir, a witch who can talk to ghosts, has kept her talents hidden ever since a disastrous middle school slumber party, choosing to be invisible and use her powers in secret to help lost souls reunite with the keys to send them home. All the while, she finds solace in a bookstore and the three mysterious women who run it… until Aline discovers the book of Mischief, and her powers are enhanced.\r\n\r\nLiving a solitary life until the age of thirty, Aline’s life takes an unexpected turn when the wrong (or perhaps right) person witnesses her using her powers and she is invited to a town that doesn’t exist on any map. Arriving in Matchstick, Aline learns of a lost magic that desperately needs to be found and only her unique powers can do it. But what she’s not told is that Magic is a person. One that is dangerous and seductive and has been waiting for a witch with a power like hers for centuries.\r\n",
                    Image = "uploads/images/35.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Griffin",
                    Isbn = "9781250905529",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 320,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book36 = new Book()
                {
                    Author = author36,
                    Title = "This Spells Disaster",
                    Description = "Fake dating gets a magical twist in this enchanting queer romantic comedy where a witch worries that the real feelings brewing between her and her crush were sparked by an accidental love potion, and the only way out of the disastrous spell is a healthy dose of the truth--drink up, witches.\r\n\r\nPotion maker and self-proclaimed \"messy witch\" Morgan Greenwood is sure she was hexed at birth. Not only did she drunkenly offer to fake date the woman of her dreams during the biennial New England Witches' festival, but Rory Sandler, spellcasting champion and brilliant elemental witch--for reasons known only to the Goddess--accepted. It's like every good luck spell Morgan ever cast came through at once, and it doesn't take a crystal ball to predict this charade will end with a broken heart.\r\n\r\nOr is the magic between them real? As Morgan and Rory prepare to fool everyone at the festival, their relationship starts to feel a whole lot less fake--right until Morgan realizes she might have screwed up the common relaxation potion she made for Rory and given her a love potion instead, breaking one of the most sacred Witch Council Laws.\r\n\r\nTo fulfill her promise to Rory, Morgan must somehow keep playing pretend while under the watchful eyes of Rory's family and legion of fans. But to break the love potion, she'll also have to prove how incompatible she and Rory really are. For a screwup like her, ruining their relationship should be easy--except every day, Morgan is becoming more bewitched by Rory herself.\r\n",
                    Image = "uploads/images/36.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "Berkley Romance",
                    Isbn = "9780593548486",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 368,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book37 = new Book()
                {
                    Author = author37,
                    Title = "After the Forest",
                    Description = "Ginger. Honey. Cinnamon. Flour. A drop of blood to bind its power.\r\n\r\n1650: The Black Forest, Wurttemberg.\r\n\r\nFifteen years after the witch in the gingerbread house, Greta and Hans are struggling to get by. Their mother and stepmother are long dead, Hans is deeply in debt from gambling, and the countryside lies in ruin, its people recovering in the aftermath of a brutal war. Greta has a secret, the witch's grimoire, secreted away and whispering in her ear, and the recipe inside that makes the most sinfully delicious - and addictive - gingerbread.\r\n\r\nAs long as she can bake, Greta can keep her small family afloat. But in a village full of superstition, Greta and her intoxicating gingerbread is a source of ever-growing suspicion and vicious gossip.\r\n\r\nAnd now, dark magic is returning to the woods and Greta's own powers - magic she is still trying to understand - may be the only thing that can save her ... If it doesn't kill her first.\r\n\r\nA stunning meld of love story, fairytale, magic and history, by an exciting debut Australian voice - perfect for fans of Naomi Novik, Bridget Collins and Kate Forsyth\r\n",
                    Image = "uploads/images/37.jpg",
                    PublishDate = new DateTime(2023, 10, 3),
                    Publisher = "Tor Books",
                    Isbn = "9781250852489",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 375,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book38 = new Book()
                {
                    Author = author38,
                    Title = "The Golem of Brooklyn",
                    Description = "In Ashkenazi Jewish folklore, a golem is a humanoid being created out of mud or clay and animated through secret prayers. Its sole purpose is to defend the Jewish people against the immediate threat of violence. It is always a rabbi who makes a golem, and always in a time of crisis.\r\n\r\nBut Len Bronstein is no rabbi—he’s a Brooklyn art teacher who steals a large quantity of clay from his school, gets extremely stoned, and manages to bring his creation to life despite knowing little about Judaism and even less about golems. Unable to communicate with his nine-foot-six, four hundred–pound, Yiddish-speaking guest, Len enlists a bodega clerk and ex-Hasid named Miri Apfelbaum to translate.\r\n\r\nEventually, the golem learns English by binge-watching Curb Your Enthusiasm after ingesting a massive amount of LSD and reveals that he is a creature with an ancestral memory; he recalls every previous iteration of himself, proving to be a repository of Jewish history and trauma. He demands to know what crisis has prompted his re-creation and whom he must destroy. When Miri shows him a video of white nationalists marching and chanting “Jews will not replace us,” the answer becomes clear.\r\n",
                    Image = "uploads/images/38.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "One World",
                    Isbn = "9780593729823",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 272,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book39 = new Book()
                {
                    Author = author39,
                    Title = "Black River Orchard",
                    Description = "A small town is transformed by dark magic when a strange tree begins bearing magical apples in this new masterpiece of horror from the bestselling author of Wanderers and The Book of Accidents.\r\n\r\nIt’s autumn in the town of Harrow, but something else is changing in the town besides the season.\r\n\r\nBecause in that town there is an orchard, and in that orchard, seven most unusual trees. And from those trees grows a new sort of apple: Strange, beautiful, with skin so red it’s nearly black.\r\n\r\nTake a bite of one of these apples and you will desire only to devour another. And another. You will become stronger. More vital. More yourself, you will believe. But then your appetite for the apples and their peculiar gifts will keep growing—and become darker.\r\n\r\nThis is what happens when the townsfolk discover the secret of the orchard. Soon it seems that everyone is consumed by an obsession with the magic of the apples… and what’s the harm, if it is making them all happier, more confident, more powerful?\r\n\r\nAnd even if buried in the orchard is something else besides the seeds of this extraordinary tree: a bloody history whose roots reach back the very origins of the town.\r\n\r\nBut now the leaves are falling. The days grow darker. And a stranger has come to town, a stranger who knows Harrow’s secrets. Because it’s harvest time, and the town will soon reap what it has sown.\r\n",
                    Image = "uploads/images/39.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Del Rey",
                    Isbn = "9780593158746",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 544,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book40 = new Book()
                {
                    Author = author40,
                    Title = "The Land of Lost Things",
                    Description = "Twice upon a time - for that is how some stories should continue . . .\r\n\r\nPhoebe, an eight-year-old girl, lies comatose following a car accident. She is a body without a spirit, a stolen child. Ceres, her mother, can only sit by her bedside and read aloud to Phoebe the fairy stories she loves in the hope they might summon her back to this world.\r\n\r\nBut it is hard to keep faith, so very hard.\r\n\r\nNow an old house on the hospital grounds, a property connected to a book written by a vanished author, is calling to Ceres. Something wants her to enter, and to journey - to a land coloured by the memories of Ceres's childhood, and the folklore beloved of her father, to a land of witches and dryads, giants and mandrakes; to a land where old enemies are watching, and waiting.\r\n",
                    Image = "uploads/images/40.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Atria/Emily Bestler Books",
                    Isbn = "9781668022283",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 358,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book41 = new Book()
                {
                    Author = author41,
                    Title = "Land of Milk and Honey",
                    Description = "A smog has spread. Food crops are rapidly disappearing. A chef escapes her dying career in a dreary city to take a job at a decadent mountaintop colony seemingly free of the world’s troubles.\r\n\r\nThere, the sky is clear again. Rare ingredients abound. Her enigmatic employer and his visionary daughter have built a lush new life for the global elite, one that reawakens the chef to the pleasures of taste, touch, and her own body.\r\n\r\nIn this atmosphere of hidden wonders and cool, seductive violence, the chef’s boundaries undergo a thrilling erosion. Soon she is pushed to the center of a startling attempt to reshape the world far beyond the plate.\r\n\r\nSensuous and surprising, joyous and bitingly sharp, told in language as alluring as it is original, Land of Milk and Honey lays provocatively bare the ethics of seeking pleasure in a dying world. It is a daringly imaginative exploration of desire and deception, privilege and faith, and the roles we play to survive. Most of all, it is a love letter to food, to wild delight, and to the transformative power of a woman embracing her own appetite.\r\n",
                    Image = "uploads/images/41.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Rivehead Books",
                    Isbn = "9780593538241",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 240,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book42 = new Book()
                {
                    Author = author42,
                    Title = "The Meadows",
                    Description = "Everyone hopes for a letter—to attend the Estuary, the Glades, the Meadows. These are the special places where only the best and brightest go to burn even brighter.\r\n\r\nWhen Eleanor is accepted at the Meadows, it means escape from her hardscrabble life by the sea, in a country ravaged by climate disaster. But despite its luminous facilities, endless fields, and pretty things, the Meadows keeps dark secrets: its purpose is to reform students, to condition them against their attractions, to show them that one way of life is the only way to survive. And maybe Eleanor would believe them, except then she meets Rose.\r\n\r\nFour years later, Eleanor and her friends seem free of the Meadows, changed but not as they’d hoped. Eleanor is an adjudicator, her job to ensure her former classmates don’t stray from the lives they’ve been trained to live. But Eleanor can’t escape her past . . . or thoughts of the girl she once loved. As secrets unfurl, Eleanor must wage a dangerous battle for her own identity and the truth of what happened to the girl she lost, knowing, if she’s not careful, Rose’s fate could be her own.\r\n",
                    Image = "uploads/images/42.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "Dial Books",
                    Isbn = "9780593111482",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 448,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book43 = new Book()
                {
                    Author = author43,
                    Title = "The World Wasn't Ready for You",
                    Description = "Justin C. Key has long been obsessed with monsters. Reading R. L. Stine’s Goosebumps as a kid, he imagined himself battling monsters and mayhem to a triumphant end. But when watching Scream 2, in which the movie’s only Black couple is promptly killed off, he realized that the Black and Brown characters in his favorite genre were almost always the victim or villain—if they were portrayed at all.\r\n\r\nIn The World Wasn’t Ready for You, Key expands and subverts the horror genre to expertly explore issues of race, class, prejudice, love, exclusion, loneliness, and what it means to be a person in the world, while revealing the horrifying nature inherent in all of us. In the opening story, “The Perfection of Theresa Watkins,” a sci-fi love story turned nightmare, a husband uses new technology to download the consciousness of his recently deceased Black wife into the body of a white woman. In “Spider King,” an inmate agrees to participate in an experimental medical study offered to Black prisoners in exchange for early release, only to find his body reacting with disturbing symptoms. And in the title story, a father tries to protect his son, teaching him how to navigate a prejudiced world that does not understand him and sees him as a threat.\r\n\r\nThe World Wasn’t Ready for You is a gripping, provocative, and distinctly original collection that demonstrates Key’s remarkable literary gifts—a skill at crafting science fiction stories equaled by an ability to sculpt characters and narrative—as well as his utterly fresh take on how genre can be used to delight, awe, frighten, and ultimately challenge our perceptions. Wildly imaginative and powerfully resonant, it introduces an unforgettable new voice in fiction.\r\n",
                    Image = "uploads/images/43.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Harper",
                    Isbn = "9780063290426",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 288,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book44 = new Book()
                {
                    Author = author44,
                    Title = "Androne",
                    Description = "In one terrifying event called the Ninety-Nine, all major military installations on earth were eviscerated. But by whom? Foreign powers, AIs, ETs? Every conceivable adversary was ruled out. Reeling from massive casualties and amid hundreds of conspiracy theories, humanity creates Andrones: bipedal android drones piloted remotely by soldiers who will never again need to be on the field of battle. Newly minted Androne pilot Sergeant Paxton Arés has now been deployed into a fight against an enemy no one understands or has ever seen.\r\n\r\nPassing mostly uneventful days patrolling an unidentified desert, Paxton spends time communicating with his pregnant girlfriend back home and reflecting on his impending fatherhood. But as he is drawn deeper into military camaraderie and begins quickly rising up the ranks on the strength of his father’s military legacy, Paxton starts to question the swirling rumors about the nature of the conflict. What he’s encountered in the shifting dunes—something inexplicable, indomitable—fills him with the fear that whatever is out there is destined to win.\r\n\r\nWhether it’s curiosity, ambition, or a newfound paternal instinct, Paxton has a driving need to understand the dangerous truths of this strange, invisible war. And the choices he must make have the power to change everything.\r\n",
                    Image = "uploads/images/44.jpg",
                    PublishDate = new DateTime(2023, 8, 1),
                    Publisher = "47North",
                    Isbn = "9781662511967",
                    Language = "English",
                    Format = "Kindle Edition",
                    Pages = 329,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book45 = new Book()
                {
                    Author = author45,
                    Title = "The Collectors",
                    Description = "From Michael L. Printz Award winner A.S. King and an all-star team of contributors including Anna-Marie McLemore and Jason Reynolds, an anthology of stories about remarkable people and their strange and surprising collections.\r\n\r\nFrom David Levithan’s story about a non-binary kid collecting pieces of other people’s collections to Jenny Torres Sanchez's tale of a girl gathering types of fire while trying not to get burned to G. Neri's piece about 1970's skaters seeking opportunities to go vertical—anything can be collected and in the hands of these award-winning and bestselling authors, any collection can tell a story. Nine of the best YA novelists working today have written fiction based on a prompt from Printz-winner A.S. King (who also contributes a story) and the result is itself an extraordinary collection.\r\n",
                    Image = "uploads/images/45.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Dutton Books for Young Readers",
                    Isbn = "9780593620281",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 272,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book46 = new Book()
                {
                    Author = author46,
                    Title = "The Free People's Village",
                    Description = "In an alternate 2020 timeline, Al Gore won the 2000 election and declared a War on Climate Change rather than a War on Terror. For twenty years, Democrats have controlled all three branches of government, enacting carbon-cutting schemes that never made it to a vote in our world. Green infrastructure projects have transformed U.S. cities into lush paradises (for the wealthy, white neighborhoods, at least), and the Bureau of Carbon Regulation levies carbon taxes on every financial transaction.\r\n\r\nEnglish teacher by day, Maddie Ryan spends her nights and weekends as the rhythm guitarist of Bunny Bloodlust, a queer punk band living in a warehouse-turned-venue called “The Lab” in Houston’s Eighth Ward. When Maddie learns that the Eighth Ward is to be sacrificed for a new electromagnetic hyperway out to the wealthy, white suburbs, she joins “Save the Eighth,” a Black-led organizing movement fighting for the neighborhood. At first, she’s only focused on keeping her band together and getting closer to Red, their reckless and enigmatic lead guitarist. But working with Save the Eighth forces Maddie to reckon with the harm she has already done to the neighborhood—both as a resident of the gentrifying Lab and as a white teacher in a predominantly Black school.\r\n\r\nWhen police respond to Save the Eighth protests with violence, the Lab becomes the epicenter of “The Free People’s Village”—an occupation that promises to be the birthplace of an anti-capitalist revolution. As the movement spreads across the U.S., Maddie dreams of a queer, liberated future with Red. But the Village is beset on all sides—by infighting, police brutality, corporate-owned media, and rising ecofascism. Maddie’s found family is increasingly at risk from state violence, and she must decide if she’s willing to sacrifice everything in pursuit of justice.",
                    Image = "uploads/images/46.jpg",
                    PublishDate = new DateTime(2023, 9, 12),
                    Publisher = "Levine Querido",
                    Isbn = "9781646142668",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 400,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book47 = new Book()
                {
                    Author = author47,
                    Title = "The Salvation Gambit",
                    Description = "Murdock has always believed in Hark, the woman who shaped her from a petty thief and lowlife hacker into a promising con artist. Hark is everything Murdock aspires to be, from her slick fashion sense to her unfailing ability to plan under pressure. Together with Bea, a fearless driver who never walks away from a bet, and Fitz, Murdock’s infuriatingly mercurial rival who can sweet-talk the galaxy into spinning around her finger, they form a foursome with a reputation for daring heists, massive payoffs, and never, ever getting caught.\r\n\r\nWell, until now.\r\n\r\nGetting caught is one thing. Getting tithed to a sentient warship that’s styled itself into a punitive god is a problem this team has never faced before. Aboard the Justice is a world stitched together from the galaxy’s sinners—some fighting for survival, some struggling to build a civilized society, and some sacrificing everything to worship the AI at the heart of the ship.\r\n\r\nThe Justice ’s all-seeing eyes are fixed on its newest acquisitions, Murdock in particular. It has use for a hacker—if it can wrest her devotion away from Hark. And Murdock’s faith is already fractured. To escape the Justice ’s madness, they need a plan, and Hark might not be up to the task.\r\n\r\nIf Hark—brilliant, unflappable Hark—can’t plot a way out, Murdock will have to use every last trick she’s learned to outwit the Justice, resist its temptation, and get her crew out alive.\r\n",
                    Image = "uploads/images/47.jpg",
                    PublishDate = new DateTime(2023, 9, 26),
                    Publisher = "Del Rey",
                    Isbn = "9780593499757",
                    Language = "English",
                    Format = "Paperback",
                    Pages = 310,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book48 = new Book()
                {
                    Author = author48,
                    Title = "Dogtown",
                    Description = "Dogtown is a shelter for stray dogs, misbehaving dogs, and discarded robot dogs, whose owners have outgrown them.\r\n\r\nChance, a real dog, has been in Dogtown since her owners unwittingly left her with irresponsible dog-sitters who skipped town.\r\n\r\nMetal Head is a robot dog who dreams of being back in a real home.\r\n\r\nAnd Mouse is a mouse who has the run of Dogtown, pilfering kibble, and performing clever feats to protect the dogs he loves.\r\n\r\nWhen Chance and Metal Head embark on an adventure to find their forever homes, there is danger, cheese sandwiches, a charging station, and some unexpected kindnesses along the way.\r\n",
                    Image = "uploads/images/48.jpg",
                    PublishDate = new DateTime(2023, 9, 19),
                    Publisher = "Feiwel & Friends",
                    Isbn = "9781250811608",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 352,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book49 = new Book()
                {
                    Author = author49,
                    Title = "Divine Might: Goddesses in Greek Myth",
                    Description = "We meet Athene, who sprang fully formed from her father’s head: goddess of war and wisdom, guardian of Athens. We run with Artemis, goddess of hunting and protector of young girls (apart from those she decides she wants as a sacrifice). Here is Aphrodite, goddess of sex and desire – there is no deity more determined and able to make you miserable if you annoy her. And then there’s the queen of all the Olympian gods: Hera, Zeus’s long-suffering wife, whose jealousy of his dalliances with mortals, nymphs and goddesses lead her to wreak elaborate, vicious revenge on those who have wronged her.\r\n\r\nWe also meet Demeter, goddess of agriculture and mother of the kidnapped Persephone, we sing the immortal song of the Muses and we warm ourselves with Hestia, goddess of the hearth and sacrificial fire. The Furies carry flames of another kind – black fires of vengeance for those who incur their wrath.\r\n\r\nThese goddesses are as mighty, revered and destructive as their male counterparts. Isn’t it time we looked beyond the columns of a ruined temple to the awesome power within?\r\n",
                    Image = "uploads/images/49.jpg",
                    PublishDate = new DateTime(2023, 9, 28),
                    Publisher = "Picador",
                    Isbn = "9781529089509",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 290,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                var book50 = new Book()
                {
                    Author = author50,
                    Title = "All the Dead Shall Weep",
                    Description = "Sisters Lizbeth Rose and Felicia as well as brother Eli and Peter, are reunited in Texoma only to break apart before the Wizard’s Ball held in San Diego, which will determine all their fates.\r\n\r\nFollowing the murderous events of the Serpent of Heaven, Lizbeth Rose is awaiting the arrival of her sister Felicia and her husband’s younger brother Eli in Texoma. Both needed to leave the seat of the Holy Russian Empire in San Diego after Felicia’s burgeoning wizardly power in death magic became the reason for kidnapping and assassination attempts from her mother’s family of high-powered wizards in Mexico.\r\n\r\nYet bad news has traveled ahead of them, as Eli is called back to San Diego, taking Peter along with him, splitting them apart in more ways than one as their enemies’ plans for revenge come to fruition.\r\n",
                    Image = "uploads/images/50.jpg",
                    PublishDate = new DateTime(2023, 9, 5),
                    Publisher = "Gallery/Saga Press",
                    Isbn = "9781982182526",
                    Language = "English",
                    Format = "Hardcover",
                    Pages = 256,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now,
                    CreatedBy = System.Environment.UserName,
                    UpdatedBy = System.Environment.UserName
                };
                if (!context!.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        book1,
                        book2,
                        book3,
                        book4,
                        book5,
                        book6,
                        book7,
                        book8,
                        book9,
                        book10,
                        book11,
                        book12,
                        book13,
                        book14,
                        book15,
                        book16,
                        book17,
                        book18,
                        book19,
                        book20,
                        book21,
                        book22,
                        book23,
                        book24,
                        book25,
                        book26,
                        book27,
                        book28,
                        book29,
                        book30,
                        book31,
                        book32,
                        book33,
                        book34,
                        book35,
                        book36,
                        book37,
                        book38,
                        book39,
                        book40,
                        book41,
                        book42,
                        book43,
                        book44,
                        book45,
                        book46,
                        book47,
                        book48,
                        book49,
                        book50,

                    });
                    context.SaveChanges();
                }

                // BookGenres
                var bookgenre1 = new BookGenre()
                {
                    BookId = book1.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre2 = new BookGenre()
                {
                    BookId = book1.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre3 = new BookGenre()
                {
                    BookId = book1.BookId,
                    GenreId = genre3.GenreId,
                };
                var bookgenre4 = new BookGenre()
                {
                    BookId = book1.BookId,
                    GenreId = genre4.GenreId,
                };
                var bookgenre5 = new BookGenre()
                {
                    BookId = book1.BookId,
                    GenreId = genre5.GenreId,
                };
                var bookgenre6 = new BookGenre()
                {
                    BookId = book2.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre7 = new BookGenre()
                {
                    BookId = book2.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre8 = new BookGenre()
                {
                    BookId = book2.BookId,
                    GenreId = genre7.GenreId,
                };
                var bookgenre9 = new BookGenre()
                {
                    BookId = book2.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre10 = new BookGenre()
                {
                    BookId = book2.BookId,
                    GenreId = genre9.GenreId,
                };
                var bookgenre11 = new BookGenre()
                {
                    BookId = book3.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre12 = new BookGenre()
                {
                    BookId = book3.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre13 = new BookGenre()
                {
                    BookId = book3.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre14 = new BookGenre()
                {
                    BookId = book3.BookId,
                    GenreId = genre10.GenreId,
                };
                var bookgenre15 = new BookGenre()
                {
                    BookId = book3.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre16 = new BookGenre()
                {
                    BookId = book4.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre17 = new BookGenre()
                {
                    BookId = book4.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre18 = new BookGenre()
                {
                    BookId = book4.BookId,
                    GenreId = genre5.GenreId,
                };
                var bookgenre20 = new BookGenre()
                {
                    BookId = book4.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre21 = new BookGenre()
                {
                    BookId = book5.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre22 = new BookGenre()
                {
                    BookId = book5.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre23 = new BookGenre()
                {
                    BookId = book5.BookId,
                    GenreId = genre5.GenreId,
                };
                var bookgenre24 = new BookGenre()
                {
                    BookId = book5.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre25 = new BookGenre()
                {
                    BookId = book5.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre26 = new BookGenre()
                {
                    BookId = book5.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre27 = new BookGenre()
                {
                    BookId = book6.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre28 = new BookGenre()
                {
                    BookId = book6.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre29 = new BookGenre()
                {
                    BookId = book6.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre30 = new BookGenre()
                {
                    BookId = book6.BookId,
                    GenreId = genre12.GenreId,
                };
                var bookgenre31 = new BookGenre()
                {
                    BookId = book7.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre32 = new BookGenre()
                {
                    BookId = book7.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre33 = new BookGenre()
                {
                    BookId = book7.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre34 = new BookGenre()
                {
                    BookId = book7.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre35 = new BookGenre()
                {
                    BookId = book8.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre36 = new BookGenre()
                {
                    BookId = book8.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre37 = new BookGenre()
                {
                    BookId = book8.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre38 = new BookGenre()
                {
                    BookId = book8.BookId,
                    GenreId = genre20.GenreId,
                };
                var bookgenre39 = new BookGenre()
                {
                    BookId = book8.BookId,
                    GenreId = genre21.GenreId,
                };
                var bookgenre40 = new BookGenre()
                {
                    BookId = book9.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre41 = new BookGenre()
                {
                    BookId = book9.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre42 = new BookGenre()
                {
                    BookId = book9.BookId,
                    GenreId = genre10.GenreId,
                };
                var bookgenre43 = new BookGenre()
                {
                    BookId = book9.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre44 = new BookGenre()
                {
                    BookId = book10.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre45 = new BookGenre()
                {
                    BookId = book10.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre46 = new BookGenre()
                {
                    BookId = book10.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre47 = new BookGenre()
                {
                    BookId = book10.BookId,
                    GenreId = genre7.GenreId,
                };
                var bookgenre48 = new BookGenre()
                {
                    BookId = book10.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre49 = new BookGenre()
                {
                    BookId = book10.BookId,
                    GenreId = genre9.GenreId,
                };
                var bookgenre50 = new BookGenre()
                {
                    BookId = book11.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre51 = new BookGenre()
                {
                    BookId = book11.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre52 = new BookGenre()
                {
                    BookId = book11.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre53 = new BookGenre()
                {
                    BookId = book11.BookId,
                    GenreId = genre28.GenreId,
                };
                var bookgenre54 = new BookGenre()
                {
                    BookId = book12.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre55 = new BookGenre()
                {
                    BookId = book12.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre56 = new BookGenre()
                {
                    BookId = book12.BookId,
                    GenreId = genre20.GenreId,
                };
                var bookgenre57 = new BookGenre()
                {
                    BookId = book12.BookId,
                    GenreId = genre24.GenreId,
                };
                var bookgenre58 = new BookGenre()
                {
                    BookId = book13.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre59 = new BookGenre()
                {
                    BookId = book13.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre60 = new BookGenre()
                {
                    BookId = book13.BookId,
                    GenreId = genre24.GenreId,
                };
                var bookgenre61 = new BookGenre()
                {
                    BookId = book13.BookId,
                    GenreId = genre32.GenreId,
                };
                var bookgenre62 = new BookGenre()
                {
                    BookId = book13.BookId,
                    GenreId = genre33.GenreId,
                };
                var bookgenre63 = new BookGenre()
                {
                    BookId = book13.BookId,
                    GenreId = genre34.GenreId,
                };
                var bookgenre64 = new BookGenre()
                {
                    BookId = book14.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre65 = new BookGenre()
                {
                    BookId = book14.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre66 = new BookGenre()
                {
                    BookId = book14.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre67 = new BookGenre()
                {
                    BookId = book14.BookId,
                    GenreId = genre32.GenreId,
                };
                var bookgenre68 = new BookGenre()
                {
                    BookId = book15.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre69 = new BookGenre()
                {
                    BookId = book15.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre70 = new BookGenre()
                {
                    BookId = book15.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre71 = new BookGenre()
                {
                    BookId = book15.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre72 = new BookGenre()
                {
                    BookId = book15.BookId,
                    GenreId = genre38.GenreId,
                };
                var bookgenre73 = new BookGenre()
                {
                    BookId = book16.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre74 = new BookGenre()
                {
                    BookId = book16.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre75 = new BookGenre()
                {
                    BookId = book16.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre76 = new BookGenre()
                {
                    BookId = book16.BookId,
                    GenreId = genre20.GenreId,
                };
                var bookgenre77 = new BookGenre()
                {
                    BookId = book16.BookId,
                    GenreId = genre21.GenreId,
                };
                var bookgenre78 = new BookGenre()
                {
                    BookId = book16.BookId,
                    GenreId = genre38.GenreId,
                };
                var bookgenre79 = new BookGenre()
                {
                    BookId = book17.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre80 = new BookGenre()
                {
                    BookId = book17.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre81 = new BookGenre()
                {
                    BookId = book17.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre82 = new BookGenre()
                {
                    BookId = book17.BookId,
                    GenreId = genre24.GenreId,
                };
                var bookgenre83 = new BookGenre()
                {
                    BookId = book17.BookId,
                    GenreId = genre32.GenreId,
                };
                var bookgenre84 = new BookGenre()
                {
                    BookId = book17.BookId,
                    GenreId = genre36.GenreId,
                };
                var bookgenre85 = new BookGenre()
                {
                    BookId = book18.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre86 = new BookGenre()
                {
                    BookId = book18.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre87 = new BookGenre()
                {
                    BookId = book18.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre88 = new BookGenre()
                {
                    BookId = book19.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre89 = new BookGenre()
                {
                    BookId = book19.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre90 = new BookGenre()
                {
                    BookId = book19.BookId,
                    GenreId = genre20.GenreId,
                };
                var bookgenre91 = new BookGenre()
                {
                    BookId = book19.BookId,
                    GenreId = genre21.GenreId,
                };
                var bookgenre92 = new BookGenre()
                {
                    BookId = book19.BookId,
                    GenreId = genre38.GenreId,
                };
                var bookgenre93 = new BookGenre()
                {
                    BookId = book20.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre94 = new BookGenre()
                {
                    BookId = book20.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre95 = new BookGenre()
                {
                    BookId = book20.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre96 = new BookGenre()
                {
                    BookId = book20.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre97 = new BookGenre()
                {
                    BookId = book20.BookId,
                    GenreId = genre31.GenreId,
                };
                var bookgenre98 = new BookGenre()
                {
                    BookId = book21.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre99 = new BookGenre()
                {
                    BookId = book21.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre100 = new BookGenre()
                {
                    BookId = book21.BookId,
                    GenreId = genre24.GenreId,
                };
                var bookgenre101 = new BookGenre()
                {
                    BookId = book21.BookId,
                    GenreId = genre32.GenreId,
                };
                var bookgenre102 = new BookGenre()
                {
                    BookId = book21.BookId,
                    GenreId = genre33.GenreId,
                };
                var bookgenre103 = new BookGenre()
                {
                    BookId = book22.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre104 = new BookGenre()
                {
                    BookId = book22.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre105 = new BookGenre()
                {
                    BookId = book22.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre106 = new BookGenre()
                {
                    BookId = book22.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre107 = new BookGenre()
                {
                    BookId = book22.BookId,
                    GenreId = genre32.GenreId,
                };
                var bookgenre108 = new BookGenre()
                {
                    BookId = book23.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre109 = new BookGenre()
                {
                    BookId = book23.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre110 = new BookGenre()
                {
                    BookId = book23.BookId,
                    GenreId = genre5.GenreId,
                };
                var bookgenre111 = new BookGenre()
                {
                    BookId = book23.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre112 = new BookGenre()
                {
                    BookId = book23.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre113 = new BookGenre()
                {
                    BookId = book24.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre114 = new BookGenre()
                {
                    BookId = book24.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre115 = new BookGenre()
                {
                    BookId = book24.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre116 = new BookGenre()
                {
                    BookId = book24.BookId,
                    GenreId = genre24.GenreId,
                };
                var bookgenre117 = new BookGenre()
                {
                    BookId = book24.BookId,
                    GenreId = genre39.GenreId,
                };
                var bookgenre118 = new BookGenre()
                {
                    BookId = book25.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre119 = new BookGenre()
                {
                    BookId = book25.BookId,
                    GenreId = genre18.GenreId,
                };
                var bookgenre120 = new BookGenre()
                {
                    BookId = book25.BookId,
                    GenreId = genre20.GenreId,
                };
                var bookgenre121 = new BookGenre()
                {
                    BookId = book25.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre122 = new BookGenre()
                {
                    BookId = book25.BookId,
                    GenreId = genre36.GenreId,
                };
                var bookgenre123 = new BookGenre()
                {
                    BookId = book26.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre124 = new BookGenre()
                {
                    BookId = book26.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre125 = new BookGenre()
                {
                    BookId = book26.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre126 = new BookGenre()
                {
                    BookId = book26.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre127 = new BookGenre()
                {
                    BookId = book26.BookId,
                    GenreId = genre26.GenreId,
                };
                var bookgenre128 = new BookGenre()
                {
                    BookId = book27.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre129 = new BookGenre()
                {
                    BookId = book27.BookId,
                    GenreId = genre12.GenreId,
                };
                var bookgenre130 = new BookGenre()
                {
                    BookId = book27.BookId,
                    GenreId = genre18.GenreId,
                };
                var bookgenre131 = new BookGenre()
                {
                    BookId = book27.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre132 = new BookGenre()
                {
                    BookId = book27.BookId,
                    GenreId = genre26.GenreId,
                };
                var bookgenre133 = new BookGenre()
                {
                    BookId = book28.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre134 = new BookGenre()
                {
                    BookId = book28.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre135 = new BookGenre()
                {
                    BookId = book28.BookId,
                    GenreId = genre24.GenreId,
                };
                var bookgenre136 = new BookGenre()
                {
                    BookId = book28.BookId,
                    GenreId = genre32.GenreId,
                };
                var bookgenre137 = new BookGenre()
                {
                    BookId = book28.BookId,
                    GenreId = genre36.GenreId,
                };
                var bookgenre138 = new BookGenre()
                {
                    BookId = book29.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre139 = new BookGenre()
                {
                    BookId = book29.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre140 = new BookGenre()
                {
                    BookId = book29.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre141 = new BookGenre()
                {
                    BookId = book29.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre142 = new BookGenre()
                {
                    BookId = book29.BookId,
                    GenreId = genre27.GenreId,
                };
                var bookgenre143 = new BookGenre()
                {
                    BookId = book30.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre144 = new BookGenre()
                {
                    BookId = book30.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre145 = new BookGenre()
                {
                    BookId = book30.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre146 = new BookGenre()
                {
                    BookId = book30.BookId,
                    GenreId = genre26.GenreId,
                };
                var bookgenre147 = new BookGenre()
                {
                    BookId = book30.BookId,
                    GenreId = genre43.GenreId,
                };
                var bookgenre148 = new BookGenre()
                {
                    BookId = book31.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre149 = new BookGenre()
                {
                    BookId = book31.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre150 = new BookGenre()
                {
                    BookId = book31.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre151 = new BookGenre()
                {
                    BookId = book31.BookId,
                    GenreId = genre10.GenreId,
                };
                var bookgenre152 = new BookGenre()
                {
                    BookId = book31.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre153 = new BookGenre()
                {
                    BookId = book32.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre154 = new BookGenre()
                {
                    BookId = book32.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre155 = new BookGenre()
                {
                    BookId = book32.BookId,
                    GenreId = genre10.GenreId,
                };
                var bookgenre156 = new BookGenre()
                {
                    BookId = book32.BookId,
                    GenreId = genre25.GenreId,
                };
                var bookgenre157 = new BookGenre()
                {
                    BookId = book32.BookId,
                    GenreId = genre27.GenreId,
                };
                var bookgenre158 = new BookGenre()
                {
                    BookId = book33.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre159 = new BookGenre()
                {
                    BookId = book33.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre160 = new BookGenre()
                {
                    BookId = book33.BookId,
                    GenreId = genre12.GenreId,
                };
                var bookgenre161 = new BookGenre()
                {
                    BookId = book33.BookId,
                    GenreId = genre20.GenreId,
                };
                var bookgenre162 = new BookGenre()
                {
                    BookId = book33.BookId,
                    GenreId = genre60.GenreId,
                };
                var bookgenre163 = new BookGenre()
                {
                    BookId = book34.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre164 = new BookGenre()
                {
                    BookId = book34.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre165 = new BookGenre()
                {
                    BookId = book34.BookId,
                    GenreId = genre20.GenreId,
                };
                var bookgenre166 = new BookGenre()
                {
                    BookId = book34.BookId,
                    GenreId = genre21.GenreId,
                };
                var bookgenre167 = new BookGenre()
                {
                    BookId = book34.BookId,
                    GenreId = genre24.GenreId,
                };
                var bookgenre168 = new BookGenre()
                {
                    BookId = book35.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre169 = new BookGenre()
                {
                    BookId = book35.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre170 = new BookGenre()
                {
                    BookId = book35.BookId,
                    GenreId = genre7.GenreId,
                };
                var bookgenre171 = new BookGenre()
                {
                    BookId = book35.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre172 = new BookGenre()
                {
                    BookId = book35.BookId,
                    GenreId = genre28.GenreId,
                };
                var bookgenre173 = new BookGenre()
                {
                    BookId = book36.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre174 = new BookGenre()
                {
                    BookId = book36.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre175 = new BookGenre()
                {
                    BookId = book36.BookId,
                    GenreId = genre7.GenreId,
                };
                var bookgenre176 = new BookGenre()
                {
                    BookId = book36.BookId,
                    GenreId = genre12.GenreId,
                };
                var bookgenre177 = new BookGenre()
                {
                    BookId = book36.BookId,
                    GenreId = genre17.GenreId,
                };
                var bookgenre178 = new BookGenre()
                {
                    BookId = book37.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre179 = new BookGenre()
                {
                    BookId = book37.BookId,
                    GenreId = genre7.GenreId,
                };
                var bookgenre180 = new BookGenre()
                {
                    BookId = book37.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre181 = new BookGenre()
                {
                    BookId = book37.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre182 = new BookGenre()
                {
                    BookId = book37.BookId,
                    GenreId = genre58.GenreId,
                };
                var bookgenre183 = new BookGenre()
                {
                    BookId = book38.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre184 = new BookGenre()
                {
                    BookId = book38.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre185 = new BookGenre()
                {
                    BookId = book38.BookId,
                    GenreId = genre51.GenreId,
                };
                var bookgenre186 = new BookGenre()
                {
                    BookId = book38.BookId,
                    GenreId = genre60.GenreId,
                };
                var bookgenre187 = new BookGenre()
                {
                    BookId = book38.BookId,
                    GenreId = genre68.GenreId,
                };
                var bookgenre188 = new BookGenre()
                {
                    BookId = book39.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre189 = new BookGenre()
                {
                    BookId = book39.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre190 = new BookGenre()
                {
                    BookId = book39.BookId,
                    GenreId = genre27.GenreId,
                };
                var bookgenre191 = new BookGenre()
                {
                    BookId = book39.BookId,
                    GenreId = genre32.GenreId,
                };
                var bookgenre192 = new BookGenre()
                {
                    BookId = book39.BookId,
                    GenreId = genre36.GenreId,
                };
                var bookgenre193 = new BookGenre()
                {
                    BookId = book40.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre194 = new BookGenre()
                {
                    BookId = book40.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre195 = new BookGenre()
                {
                    BookId = book40.BookId,
                    GenreId = genre28.GenreId,
                };
                var bookgenre196 = new BookGenre()
                {
                    BookId = book40.BookId,
                    GenreId = genre36.GenreId,
                };
                var bookgenre197 = new BookGenre()
                {
                    BookId = book40.BookId,
                    GenreId = genre59.GenreId,
                };
                var bookgenre198 = new BookGenre()
                {
                    BookId = book41.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre199 = new BookGenre()
                {
                    BookId = book41.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre200 = new BookGenre()
                {
                    BookId = book41.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre201 = new BookGenre()
                {
                    BookId = book41.BookId,
                    GenreId = genre38.GenreId,
                };
                var bookgenre202 = new BookGenre()
                {
                    BookId = book41.BookId,
                    GenreId = genre50.GenreId,
                };
                var bookgenre203 = new BookGenre()
                {
                    BookId = book42.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre204 = new BookGenre()
                {
                    BookId = book42.BookId,
                    GenreId = genre12.GenreId,
                };
                var bookgenre205 = new BookGenre()
                {
                    BookId = book42.BookId,
                    GenreId = genre17.GenreId,
                };
                var bookgenre206 = new BookGenre()
                {
                    BookId = book42.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre207 = new BookGenre()
                {
                    BookId = book42.BookId,
                    GenreId = genre79.GenreId,
                };
                var bookgenre208 = new BookGenre()
                {
                    BookId = book43.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre209 = new BookGenre()
                {
                    BookId = book43.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre210 = new BookGenre()
                {
                    BookId = book43.BookId,
                    GenreId = genre36.GenreId,
                };
                var bookgenre211 = new BookGenre()
                {
                    BookId = book43.BookId,
                    GenreId = genre50.GenreId,
                };
                var bookgenre212 = new BookGenre()
                {
                    BookId = book44.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre213 = new BookGenre()
                {
                    BookId = book44.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre214 = new BookGenre()
                {
                    BookId = book44.BookId,
                    GenreId = genre50.GenreId,
                };
                var bookgenre215 = new BookGenre()
                {
                    BookId = book44.BookId,
                    GenreId = genre79.GenreId,
                };
                var bookgenre216 = new BookGenre()
                {
                    BookId = book45.BookId,
                    GenreId = genre2.GenreId,
                };
                var bookgenre217 = new BookGenre()
                {
                    BookId = book45.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre218 = new BookGenre()
                {
                    BookId = book45.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre219 = new BookGenre()
                {
                    BookId = book45.BookId,
                    GenreId = genre81.GenreId,
                };
                var bookgenre220 = new BookGenre()
                {
                    BookId = book45.BookId,
                    GenreId = genre82.GenreId,
                };
                var bookgenre221 = new BookGenre()
                {
                    BookId = book46.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre222 = new BookGenre()
                {
                    BookId = book46.BookId,
                    GenreId = genre11.GenreId,
                };
                var bookgenre223 = new BookGenre()
                {
                    BookId = book46.BookId,
                    GenreId = genre12.GenreId,
                };
                var bookgenre224 = new BookGenre()
                {
                    BookId = book46.BookId,
                    GenreId = genre18.GenreId,
                };
                var bookgenre225 = new BookGenre()
                {
                    BookId = book46.BookId,
                    GenreId = genre50.GenreId,
                };
                var bookgenre226 = new BookGenre()
                {
                    BookId = book47.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre227 = new BookGenre()
                {
                    BookId = book47.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre228 = new BookGenre()
                {
                    BookId = book47.BookId,
                    GenreId = genre12.GenreId,
                };
                var bookgenre229 = new BookGenre()
                {
                    BookId = book47.BookId,
                    GenreId = genre18.GenreId,
                };
                var bookgenre230 = new BookGenre()
                {
                    BookId = book47.BookId,
                    GenreId = genre50.GenreId,
                };
                var bookgenre231 = new BookGenre()
                {
                    BookId = book48.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre232 = new BookGenre()
                {
                    BookId = book48.BookId,
                    GenreId = genre23.GenreId,
                };
                var bookgenre233 = new BookGenre()
                {
                    BookId = book48.BookId,
                    GenreId = genre44.GenreId,
                };
                var bookgenre234 = new BookGenre()
                {
                    BookId = book48.BookId,
                    GenreId = genre54.GenreId,
                };
                var bookgenre235 = new BookGenre()
                {
                    BookId = book48.BookId,
                    GenreId = genre56.GenreId,
                };
                var bookgenre236 = new BookGenre()
                {
                    BookId = book49.BookId,
                    GenreId = genre13.GenreId,
                };
                var bookgenre237 = new BookGenre()
                {
                    BookId = book49.BookId,
                    GenreId = genre21.GenreId,
                };
                var bookgenre238 = new BookGenre()
                {
                    BookId = book49.BookId,
                    GenreId = genre43.GenreId,
                };
                var bookgenre239 = new BookGenre()
                {
                    BookId = book49.BookId,
                    GenreId = genre45.GenreId,
                };
                var bookgenre240 = new BookGenre()
                {
                    BookId = book49.BookId,
                    GenreId = genre58.GenreId,
                };
                var bookgenre241 = new BookGenre()
                {
                    BookId = book50.BookId,
                    GenreId = genre1.GenreId,
                };
                var bookgenre242 = new BookGenre()
                {
                    BookId = book50.BookId,
                    GenreId = genre6.GenreId,
                };
                var bookgenre243 = new BookGenre()
                {
                    BookId = book50.BookId,
                    GenreId = genre8.GenreId,
                };
                var bookgenre244 = new BookGenre()
                {
                    BookId = book50.BookId,
                    GenreId = genre24.GenreId,
                };
                var bookgenre245 = new BookGenre()
                {
                    BookId = book50.BookId,
                    GenreId = genre28.GenreId,
                };

                if (!context!.BookGenres.Any())
                {
                    context.BookGenres.AddRange(new List<BookGenre>()
                    {
                        bookgenre1,
                        bookgenre2,
                        bookgenre3,
                        bookgenre4,
                        bookgenre5,
                        bookgenre6,
                        bookgenre7,
                        bookgenre8,
                        bookgenre9,
                        bookgenre10,
                        bookgenre11,
                        bookgenre12,
                        bookgenre13,
                        bookgenre14,
                        bookgenre15,
                        bookgenre16,
                        bookgenre17,
                        bookgenre18,
                        bookgenre20,
                        bookgenre21,
                        bookgenre22,
                        bookgenre23,
                        bookgenre24,
                        bookgenre25,
                        bookgenre26,
                        bookgenre27,
                        bookgenre28,
                        bookgenre29,
                        bookgenre30,
                        bookgenre31,
                        bookgenre32,
                        bookgenre33,
                        bookgenre34,
                        bookgenre35,
                        bookgenre36,
                        bookgenre37,
                        bookgenre38,
                        bookgenre39,
                        bookgenre40,
                        bookgenre41,
                        bookgenre42,
                        bookgenre43,
                        bookgenre44,
                        bookgenre45,
                        bookgenre46,
                        bookgenre47,
                        bookgenre48,
                        bookgenre49,
                        bookgenre50,
                        bookgenre51,
                        bookgenre52,
                        bookgenre53,
                        bookgenre54,
                        bookgenre55,
                        bookgenre56,
                        bookgenre57,
                        bookgenre58,
                        bookgenre59,
                        bookgenre60,
                        bookgenre61,
                        bookgenre62,
                        bookgenre63,
                        bookgenre64,
                        bookgenre65,
                        bookgenre66,
                        bookgenre67,
                        bookgenre68,
                        bookgenre69,
                        bookgenre70,
                        bookgenre71,
                        bookgenre72,
                        bookgenre73,
                        bookgenre74,
                        bookgenre75,
                        bookgenre76,
                        bookgenre77,
                        bookgenre78,
                        bookgenre79,
                        bookgenre80,
                        bookgenre81,
                        bookgenre82,
                        bookgenre83,
                        bookgenre84,
                        bookgenre85,
                        bookgenre86,
                        bookgenre87,
                        bookgenre88,
                        bookgenre89,
                        bookgenre90,
                        bookgenre91,
                        bookgenre92,
                        bookgenre93,
                        bookgenre94,
                        bookgenre95,
                        bookgenre96,
                        bookgenre97,
                        bookgenre98,
                        bookgenre99,
                        bookgenre100,
                        bookgenre101,
                        bookgenre102,
                        bookgenre103,
                        bookgenre104,
                        bookgenre105,
                        bookgenre106,
                        bookgenre107,
                        bookgenre108,
                        bookgenre109,
                        bookgenre110,
                        bookgenre111,
                        bookgenre112,
                        bookgenre113,
                        bookgenre114,
                        bookgenre115,
                        bookgenre116,
                        bookgenre117,
                        bookgenre118,
                        bookgenre119,
                        bookgenre120,
                        bookgenre121,
                        bookgenre122,
                        bookgenre123,
                        bookgenre124,
                        bookgenre125,
                        bookgenre126,
                        bookgenre127,
                        bookgenre128,
                        bookgenre129,
                        bookgenre130,
                        bookgenre131,
                        bookgenre132,
                        bookgenre133,
                        bookgenre134,
                        bookgenre135,
                        bookgenre136,
                        bookgenre137,
                        bookgenre138,
                        bookgenre139,
                        bookgenre140,
                        bookgenre141,
                        bookgenre142,
                        bookgenre143,
                        bookgenre144,
                        bookgenre145,
                        bookgenre146,
                        bookgenre147,
                        bookgenre148,
                        bookgenre149,
                        bookgenre150,
                        bookgenre151,
                        bookgenre152,
                        bookgenre153,
                        bookgenre154,
                        bookgenre155,
                        bookgenre156,
                        bookgenre157,
                        bookgenre158,
                        bookgenre159,
                        bookgenre160,
                        bookgenre161,
                        bookgenre162,
                        bookgenre163,
                        bookgenre164,
                        bookgenre165,
                        bookgenre166,
                        bookgenre167,
                        bookgenre168,
                        bookgenre169,
                        bookgenre170,
                        bookgenre171,
                        bookgenre172,
                        bookgenre173,
                        bookgenre174,
                        bookgenre175,
                        bookgenre176,
                        bookgenre177,
                        bookgenre178,
                        bookgenre179,
                        bookgenre180,
                        bookgenre181,
                        bookgenre182,
                        bookgenre183,
                        bookgenre184,
                        bookgenre185,
                        bookgenre186,
                        bookgenre187,
                        bookgenre188,
                        bookgenre189,
                        bookgenre190,
                        bookgenre191,
                        bookgenre192,
                        bookgenre193,
                        bookgenre194,
                        bookgenre195,
                        bookgenre196,
                        bookgenre197,
                        bookgenre198,
                        bookgenre199,
                        bookgenre200,
                        bookgenre201,
                        bookgenre202,
                        bookgenre203,
                        bookgenre204,
                        bookgenre205,
                        bookgenre206,
                        bookgenre207,
                        bookgenre208,
                        bookgenre209,
                        bookgenre210,
                        bookgenre211,
                        bookgenre212,
                        bookgenre213,
                        bookgenre214,
                        bookgenre215,
                        bookgenre216,
                        bookgenre217,
                        bookgenre218,
                        bookgenre219,
                        bookgenre220,
                        bookgenre221,
                        bookgenre222,
                        bookgenre223,
                        bookgenre224,
                        bookgenre225,
                        bookgenre226,
                        bookgenre227,
                        bookgenre228,
                        bookgenre229,
                        bookgenre230,
                        bookgenre231,
                        bookgenre232,
                        bookgenre233,
                        bookgenre234,
                        bookgenre235,
                        bookgenre236,
                        bookgenre237,
                        bookgenre238,
                        bookgenre239,
                        bookgenre240,
                        bookgenre241,
                        bookgenre242,
                        bookgenre243,
                        bookgenre244,
                        bookgenre245,

                    });
                    context.SaveChanges();
                }

                // Reviews
                var review1 = new Review()
                {
                    Book = book1,
                    Name = "reviewer1",
                    UserEmail = "reviewer1@gmail.com",
                    Rating = 5,
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
                    Name = "reviewer1",
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


