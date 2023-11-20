using AutoMapper;
using Cinema.BLL.DTOs;
using Cinema.Core.Entities;
using Cinema.Core.IRepository;
using Cinema.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Services.Actors
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IActorFilmRepository _actorFilm;
        private readonly IMapper _mapper;

        public ActorService(IActorRepository actorRepository, IActorFilmRepository actorFilm ,IMapper mapper)
        {
            _actorRepository = actorRepository;
            _actorFilm = actorFilm;
            _mapper = mapper;
        }
        public async Task<bool> AddActor(ActorCreateDTO actor)
        {
            Actor addedActor = _mapper.Map<Actor>(actor);
            bool result = await _actorRepository.Create(addedActor);
            if (actor.ActorFilmList.Count > 0)
            {
                List<ActorFilm> actorFilms = new List<ActorFilm>();
                foreach (FilmCategoriesDTO film in actor.ActorFilmList)
                {
                    ActorFilm actorFilm = new()
                    {
                        ActorId = addedActor.Id,
                        FilmId = film.Id
                    };
                    actorFilms.Add(actorFilm);
                }
                return await _actorFilm.AddActorFilm(actorFilms);
            }
            return result;
        }

        public async Task<List<ActorCreateDTO>> getAllActors()
        {
            List<Actor> actors = await _actorRepository.GetAll();
            List<ActorCreateDTO> actorDTO = _mapper.Map<List<ActorCreateDTO>>(actors);
            return actorDTO;
        }

        public async Task<List<ActorCreateDTO>> getAllActorsIncludFilms()
        {
            //List<Actor> actors = await _actorRepository.GetIncludeAll();
            //List<ActorCreateDTO> actorDTO = new();
            //foreach (Actor actor in actors)
            //{
            //    ActorCreateDTO actorDto = new ActorCreateDTO()
            //    {
            //        ID = actor.Id,
            //        Name = actor.Name,
            //        AwardCount = actor.AwardCount,
            //        BirthDate = actor.BirthDate,
            //        Gender = actor.Gender,
            //    };

            //    if (actor.ActorFilms.Count > 0)
            //    {
            //        List<FilmCategoriesDTO> actorFilms = new();
            //        foreach (ActorFilm item in actor.ActorFilms)
            //        {
            //            FilmCategoriesDTO filmCategory = new()
            //            {
            //                Id = item.FilmId,
            //                Name = item.Film.Name
            //            };
            //            actorFilms.Add(filmCategory);
            //        }
            //        actorDto.ActorFilmList = actorFilms;
            //    }

            //    actorDTO.Add(actorDto);
            //}
            //return actorDTO;

            List<Actor> actors = await _actorRepository.GetIncludeAll();

            List<ActorCreateDTO> actorDTO = actors.Select(actor => _mapper.Map<ActorCreateDTO>(actor)).ToList();

            return actorDTO;
        }

        public async Task<bool> RemoveActor(int id)
        {
            return await _actorRepository.Delete(id);
        }

        public async Task<bool> UpdateActor(ActorUpdateDTO actor)
        {
            Actor updatedActor = _mapper.Map<Actor>(actor);
            return await _actorRepository.Update(updatedActor);
        }
    }
}
