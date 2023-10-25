using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IGenreRepository
    {
        IQueryable<Genre> GetGenres();
        void AddGenre(Genre genre);
        void DeleteGenre(int genreId);
        void EditGenre(Genre genre);
        bool GenreExists(string name);
        Genre? GetGenreByName(string name);
    }
}
