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
    public class CategoryFilmRepository : ICategoryFilmRepository
    {
        private readonly AppDbContext _context;

        public CategoryFilmRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCategoryFilm(List<CategoryFilm> categoryFilm)
        {
            await _context.CategoryFilms.AddRangeAsync(categoryFilm);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
