using Data.Models;
using Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenre(int genreId);
        void AddGenre(GenreViewModel model);
        void DeleteGenre(int genreId);
        void EditGenre(int genreId, BookViewModel model);
    }
}
