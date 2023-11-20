using Cinema.Core.Entities;
using Cinema.Core.IRepository;
using Cinema.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository
{
    public class ActorRepository : BaseRepository<Actor>, IActorRepository
    {
        private readonly AppDbContext _context;

        public ActorRepository(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<List<Actor>> GetIncludeAll()
        {
            return await _context.Actors.Include(x => x.ActorFilms).ThenInclude(x=> x.Film).ToListAsync();
        }
    }
}
