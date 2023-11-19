using Cinema.Core.Entities;
using Cinema.Core.IRepository;
using Cinema.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository
{
    public class ActorFilmRepository : IActorFilmRepository
    {
        private readonly AppDbContext _context;

        public ActorFilmRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddActorFilm(List<ActorFilm> actorFilm)
        {
            await _context.ActorFilms.AddRangeAsync(actorFilm);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
