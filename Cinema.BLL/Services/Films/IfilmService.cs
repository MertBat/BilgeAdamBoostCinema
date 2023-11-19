using Cinema.BLL.DTOs;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services.Films
{
    public interface IfilmService
    {
        Task<List<FilmCreateDTO>> getAllFilms();
        Task<List<FilmCreateDTO>> getAllFilmsIncludeCategories();
        Task<bool> AddFilm(FilmCreateDTO film);
        Task<bool> RemoveFilm(int id);
        Task<bool> UpdateFilm(FilmUpdateDTO film);
    }
}
