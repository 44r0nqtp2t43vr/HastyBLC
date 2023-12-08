﻿using Data.Interfaces;
using Data;
using Data.Models;
using Services.Interfaces;
using Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace Services.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        public GenreService(IGenreRepository repository, HastyDBContext dbContext)
        {
            _repository = repository;
        }
        public IEnumerable<Genre> GetGenres()
        {
            return _repository.GetGenres().ToList();
        }
        public Genre GetGenre(int genreId)
        {
            var genreWithBooks = _repository.GetGenres().AsQueryable()
                .Where(genre => genre.GenreId == genreId)
                .Include(genre => genre.BookGenres!)
                    .ThenInclude(bookGenre => bookGenre.Book)
                .ToList();
            return genreWithBooks[0];
        }
        public void AddGenre(GenreViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name))
            {
                throw new InvalidDataException();
            }
            var genre = new Genre();
            if (!_repository.GenreExists(model.Name.Trim()))
            {
                genre.Name = model.Name.Trim();
                genre.CreatedTime = DateTime.Now;
                genre.UpdatedTime = DateTime.Now;
                genre.CreatedBy = System.Environment.UserName;
                genre.UpdatedBy = System.Environment.UserName;

                _repository.AddGenre(genre);
            }
            else
            {
                throw new InvalidDataException();
            }
        }
        public void DeleteGenre(int genreId)
        {
            _repository.DeleteGenre(genreId);
        }
        public void EditGenre(GenreViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name))
            {
                throw new InvalidDataException();
            }
            if (!_repository.GenreExists(model.Name.Trim()))
            {
                var genre = new Genre();
                genre.GenreId = model.GenreId;
                genre.Name = model.Name.Trim();
                genre.UpdatedTime = DateTime.Now;
                genre.UpdatedBy = System.Environment.UserName;
                _repository.EditGenre(genre);
            }
            else
            {
                throw new InvalidDataException(Resources.Messages.Errors.GenreExists);
            }
        }
    }
}
