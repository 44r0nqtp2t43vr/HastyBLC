using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public IQueryable<Genre> GetGenres()
        {
            return this.GetDbSet<Genre>();
        }
        public void AddGenre(Genre genre)
        {
            this.GetDbSet<Genre>().Add(genre);
            UnitOfWork.SaveChanges();
        }
        public void DeleteGenre(int genreId)
        {
            try
            {
                var genre = this.GetDbSet<Genre>().Find(genreId);
                if (genre != null)
                {
                    this.GetDbSet<Genre>().Remove(genre);
                    UnitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception here to see if any error is occurring
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        public void EditGenre(Genre genre)
        {
            var existingGenre = this.GetDbSet<Genre>().Find(genre.GenreId);

            if (existingGenre != null)
            {
                existingGenre.Name = genre.Name;
                UnitOfWork.SaveChanges();
            }
        }
        public bool GenreExists(string name)
        {
            return this.GetDbSet<Genre>().Any(x => x.Name != null && x.Name.ToLower() == name.ToLower());
        }
        public Genre? GetGenreByName(string name)
        {
            return this.GetDbSet<Genre>().FirstOrDefault(x => x.Name == name);
        }
    }
}
