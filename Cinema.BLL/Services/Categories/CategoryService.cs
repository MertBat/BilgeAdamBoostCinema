using AutoMapper;
using Cinema.BLL.DTOs;
using Cinema.Core.Entities;
using Cinema.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryFilmRepository _categoryFilmRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, ICategoryFilmRepository categoryFilmRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _categoryFilmRepository = categoryFilmRepository;
            _mapper = mapper;
        }
        public async Task<bool> AddCategory(CategoryCreateDTO category)
        {
            Category addedcategory = _mapper.Map<Category>(category);
            bool result = await _categoryRepository.Create(addedcategory);
            List<CategoryFilm> categories = new();
            foreach (FilmCategoriesDTO item in category.CategoryFilmList)
            {
                CategoryFilm categoryfilm = new()
                {
                    CategoryId = addedcategory.Id,
                    FilmId = item.Id,
                };
                categories.Add(categoryfilm);
            }
            result = await _categoryFilmRepository.AddCategoryFilm(categories);
            return result;
        }

        public async Task<List<CategoryCreateDTO>> getAllActorsIncludCategories()
        {
            List<Category> categories = await _categoryRepository.GetIncludeAll();
            List<CategoryCreateDTO> categoryCreateDTOs = categories.Select(category => _mapper.Map<CategoryCreateDTO>(category)).ToList();
            return categoryCreateDTOs;
        }

        public Task<List<CategoryCreateDTO>> getAllCategories()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveCategory(int id)
        {
            return await _categoryRepository.Delete(id);
        }

        public async Task<bool> UpdateCategory(CategoryUpdateDTO category)
        {
            Category updatedCategory = _mapper.Map<Category>(category);
            return await _categoryRepository.Update(updatedCategory);   
        }
    }
}
