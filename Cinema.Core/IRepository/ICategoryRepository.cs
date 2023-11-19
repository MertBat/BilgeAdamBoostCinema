using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.IRepository
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetIncludeAll(Expression<Func<Category, bool>>? expression = null);
    }
}
