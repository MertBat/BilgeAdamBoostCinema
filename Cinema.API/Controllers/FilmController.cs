using Cinema.BLL.DTOs;
using Cinema.BLL.Services.Films;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IfilmService _filmService;

        public FilmController(IfilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<IActionResult> getAllData()
        {
            List<FilmCreateDTO> filmDTOs = await _filmService.getAllFilmsIncludeCategories();
            if (filmDTOs.Count <= 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok(filmDTOs);
            }

        }

        [HttpPost]
        public async Task<IActionResult> PostFilm([FromBody]FilmCreateDTO filmDTO)
        {
            bool response = await _filmService.AddFilm(filmDTO);
            if (!response)
                return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] FilmUpdateDTO filmDTO)
        {
            bool response = await _filmService.UpdateFilm(filmDTO);
            if (!response)
                return BadRequest();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _filmService.RemoveFilm(id);
            if (!response)
                return BadRequest();
            return Ok();
        }
    }
}
