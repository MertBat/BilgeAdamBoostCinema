using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.IRepository
{
    public interface IBaseRepository<T> where T : BaseClass
    {
        Task<List<T>> GetAll(Expression<Func<T,bool>>? expression = null);
        Task<T> GetById(int id);
        Task<bool> Create(T enitity);
        Task<bool> Update(T enitity);
        Task<bool> Delete(int id);
        Task<bool> Save();

    }
}
