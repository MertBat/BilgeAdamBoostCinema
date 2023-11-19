using Cinema.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Entities
{
    public class Actor : BaseClass
    {
        public Actor()
        {
            ActorFilms = new List<ActorFilm>();  
        }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int AwardCount { get; set; }
        public List<ActorFilm> ActorFilms { get; set; }

    }
}
