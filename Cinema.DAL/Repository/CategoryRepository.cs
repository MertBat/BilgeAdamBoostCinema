using Cinema.Core.Entities;
using Cinema.Core.IRepository;
using Cinema.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Repository
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context): base(context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetIncludeAll(Expression<Func<Category, bool>>? expression = null)
        {
            if (expression == null)
            {
                return await _context.Categories.Include(x => x.CategoryFilms).ThenInclude(x=> x.Film).ToListAsync();
            }
            else
            {
                return await _context.Categories.Include(x => x.CategoryFilms).ThenInclude(x => x.Film).Where(expression).ToListAsync();
            }

        }
    }
}
