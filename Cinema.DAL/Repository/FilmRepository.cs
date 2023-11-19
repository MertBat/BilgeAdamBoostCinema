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
    public class FilmRepository : BaseRepository<Film>, IFilmRepository
    {
        private readonly AppDbContext _context;

        public FilmRepository(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task<List<Film>> GetIncludeAll()
        {
            return await _context.Films.Include(x => x.CategoryFilms).ThenInclude(x=> x.Category).ToListAsync();
        }
    }
}
