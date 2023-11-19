using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Entities
{
    public class ActorFilm
    {
        public int ActorId { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public Actor Actor { get; set; }
    }
}
