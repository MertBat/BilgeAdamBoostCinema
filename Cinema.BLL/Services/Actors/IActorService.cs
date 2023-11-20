using Cinema.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services.Actors
{
    public interface IActorService
    {
        Task<List<ActorCreateDTO>> getAllActors();
        Task<List<ActorCreateDTO>> getAllActorsIncludFilms();
        Task<bool> AddActor(ActorCreateDTO actor);
        Task<bool> RemoveActor(int id);
        Task<bool> UpdateActor(ActorUpdateDTO actor);
    }
}
