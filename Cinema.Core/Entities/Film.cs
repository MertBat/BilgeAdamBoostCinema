using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Entities
{
    public class Film : BaseClass
    {
        public Film()
        {
            ActorFilm actorFilm = new ActorFilm();
            CategoryFilm categoryFilm = new CategoryFilm(); 
        }
        public DateTime PublishedDate { get; set; }
        public List<ActorFilm> ActorFilms { get; set; }
        public List<CategoryFilm>? CategoryFilms { get; set; }
    }
}
