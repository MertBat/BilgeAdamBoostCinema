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
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseClass
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> Table;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            Table = context.Set<T>();
        }

        public async Task<bool> Create(T enitity)
        {
            await Table.AddAsync(enitity);
            return await Save();
        }

        public async Task<bool> Delete(int id)
        {
            T entity = await GetById(id);
            if(entity is not null)
            {
                Table.Remove(entity);
                return await Save();
            }
            return false;
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? expression = null)
        {
            if(expression == null)
            {
                return await Table.ToListAsync();
            }
            else
            {
                return await Table.Where(expression).ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            return await Table.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(T enitity)
        {
            Table.Update(enitity);
            return await Save();
        }
    }
}
