﻿using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
{
    public class BookSearchViewModel
    {
        public string? SearchText { get; set; }
        public List<Book>? Books { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<bool>? IsGenreSelected { get; set; }
    }

}
