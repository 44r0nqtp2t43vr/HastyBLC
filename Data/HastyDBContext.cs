using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Data.Models;

namespace Data
{
    public partial class HastyDBContext : DbContext
    {
        public HastyDBContext()
        {
        }

        public HastyDBContext(DbContextOptions<HastyDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.Attribute> Attributes { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAttribute> RoleAttributes { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRoleAttribute> UserRoleAttributes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);
            });

            // Attribute
            modelBuilder.Entity<Models.Attribute>(entity =>
            {
                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Type)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);
            });

            // RoleAttribute
            modelBuilder.Entity<RoleAttribute>(entity =>
            {
                // Define a foreign key to the Role entity
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAttributes)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Define a foreign key to the Attribute entity
                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.RoleAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email, "UQ__Users__1788CC4D5F4A160F")
                    .IsUnique();

                // Define a foreign key to the Role entity
                entity.HasOne(d => d.Role) // User has one Role
                    .WithMany(p => p.Users)     // Role has many Users
                    .HasForeignKey(d => d.RoleId) // Foreign key property in the User entity
                    .OnDelete(DeleteBehavior.ClientSetNull); // Define the delete behavior

                entity.Property(e => e.Username)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            // UserRoleAttribute
            modelBuilder.Entity<UserRoleAttribute>(entity =>
            {
                // Define a foreign key to the User entity
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleAttributes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Define a foreign key to the RoleAttribute entity
                entity.HasOne(d => d.RoleAttribute)
                    .WithMany(p => p.UserRoleAttributes)
                    .HasForeignKey(d => d.RoleAttributeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Value)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);
            });

            // Author
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);
            });

            // Genre
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            // Book
            modelBuilder.Entity<Book>(entity =>
            {
                // Define a foreign key to the Author entity
                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(500)
                   .IsUnicode(false);

                entity.Property(e => e.Image)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Publisher)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Isbn)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Language)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Format)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Pages)
                   .IsRequired();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            // BookGenre
            modelBuilder.Entity<BookGenre>(entity =>
            {
                // Define a foreign key to the Book entity
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Define a foreign key to the Genre entity
                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Rating
            modelBuilder.Entity<Rating>(entity =>
            {
                // Define a foreign key to the User entity
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Define a foreign key to the Book entity
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Value)
                   .IsRequired();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            // Review
            modelBuilder.Entity<Review>(entity =>
            {
                // Define a foreign key to the Rating entity
                entity.HasOne(d => d.Rating)
                    .WithOne()
                    .HasForeignKey<Rating>(d => d.RatingId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            // Comment
            modelBuilder.Entity<Comment>(entity =>
            {
                // Define a foreign key to the User entity
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Define a foreign key to the Review entity
                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.ReviewId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
