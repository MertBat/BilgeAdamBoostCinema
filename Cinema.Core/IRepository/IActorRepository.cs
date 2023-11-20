using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.IRepository
{
    public interface IActorRepository : IBaseRepository<Actor>
    {
        Task<List<Actor>> GetIncludeAll();
    }
}
