using AutoMapper;
using Cinema.BLL.DTOs;
using Cinema.Core.Entities;
using Cinema.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services.Films
{
    public class FilmService : IfilmService
    {
        private readonly IFilmRepository _filmRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFilmRepository _categoryFilmRepository;
        private readonly IMapper _mapper;

        public FilmService(IFilmRepository filmRepository, ICategoryRepository categoryRepository, ICategoryFilmRepository categoryFilmRepository, IMapper mapper)
        {
            _filmRepository = filmRepository;
            _categoryRepository = categoryRepository;
            _categoryFilmRepository = categoryFilmRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddFilm(FilmCreateDTO film)
        {
            Film addedFilm = _mapper.Map<Film>(film);
            bool result = await _filmRepository.Create(addedFilm);
            if (film.CategoriesList.Count > 0)
            {
                List<CategoryFilm> categoryFilms = new List<CategoryFilm>();
                foreach (FilmCategoriesDTO category in film.CategoriesList)
                {
                    CategoryFilm categoryFilm = new()
                    {
                        CategoryId = category.Id,
                        FilmId = addedFilm.Id
                    };
                    categoryFilms.Add(categoryFilm);
                }
                return await _categoryFilmRepository.AddCategoryFilm(categoryFilms);
            }
            return result;
        }

        public async Task<List<FilmCreateDTO>> getAllFilms()
        {
            List<Film> films = await _filmRepository.GetAll();
            List<FilmCreateDTO> filmDTOs = _mapper.Map<List<FilmCreateDTO>>(films);
            return filmDTOs;
        }

        public async Task<List<FilmCreateDTO>> getAllFilmsIncludeCategories()
        {
            List<Film> films = await _filmRepository.GetIncludeAll();
            List<FilmCreateDTO> filmDTOs = new();
            foreach (Film film in films)
            {
                FilmCreateDTO filmDto = new FilmCreateDTO()
                {
                    Name = film.Name,
                    PublishedDate = film.PublishedDate,
                    Id = film.Id,
                };

                if (film.CategoryFilms.Count > 0)
                {
                    List<FilmCategoriesDTO> filmCategories = new();
                    foreach (CategoryFilm item in film.CategoryFilms)
                    {
                        FilmCategoriesDTO filmCategory = new()
                        {
                            Id = item.CategoryId,
                            Name = item.Category.Name
                        };
                        filmCategories.Add(filmCategory);
                    }
                    filmDto.CategoriesList = filmCategories;
                }

                filmDTOs.Add(filmDto);
            }
            return filmDTOs;
        }

        public Task<bool> RemoveFilm(int id)
        {
            return _filmRepository.Delete(id);
        }

        public Task<bool> UpdateFilm(FilmUpdateDTO film)
        {
            Film UpdatedFilm = _mapper.Map<Film>(film);
            return _filmRepository.Update(UpdatedFilm);
        }
    }
}
