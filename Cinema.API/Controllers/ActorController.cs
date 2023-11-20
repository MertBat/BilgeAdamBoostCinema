using Cinema.BLL.DTOs;
using Cinema.BLL.Services.Actors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<ActorCreateDTO> actorCreatesDTO = await _actorService.getAllActorsIncludFilms();
            return Ok(actorCreatesDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ActorCreateDTO actorCreateDTO)
        {
            bool result = await _actorService.AddActor(actorCreateDTO);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Change([FromBody]ActorUpdateDTO updateDTO)
        {
            bool result = await _actorService.UpdateActor(updateDTO);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await _actorService.RemoveActor(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
