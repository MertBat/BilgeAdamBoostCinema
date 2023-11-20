using Cinema.BLL.DTOs;
using Cinema.BLL.Services.Actors;
using Cinema.BLL.Services.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<CategoryCreateDTO> categoryCreateDTO = await _categoryService.getAllActorsIncludCategories();
            return Ok(categoryCreateDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryCreateDTO categoryCreateDTO)
        {
            bool result = await _categoryService.AddCategory(categoryCreateDTO);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Change([FromBody] CategoryUpdateDTO categoryUpdateDTO)
        {
            bool result = await _categoryService.UpdateCategory(categoryUpdateDTO);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _categoryService.RemoveCategory(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
