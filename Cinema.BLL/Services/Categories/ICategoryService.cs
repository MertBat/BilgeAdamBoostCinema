using Cinema.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services.Categories
{
    public interface ICategoryService
    {
        Task<List<CategoryCreateDTO>> getAllCategories();
        Task<List<CategoryCreateDTO>> getAllActorsIncludCategories();
        Task<bool> AddCategory(CategoryCreateDTO actor);
        Task<bool> RemoveCategory(int id);
        Task<bool> UpdateCategory(CategoryUpdateDTO actor);
    }
}
