using HastyBLC.Models;
using Microsoft.EntityFrameworkCore;

namespace HastyBLCAdmin.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<HastyBLC.Models.Attribute> Attributes { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAttribute> RoleAttributes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRoleAttribute> UserRoleAttributes { get; set; }
    }
}
