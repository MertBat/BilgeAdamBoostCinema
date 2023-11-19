using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Entities
{
    public class Category : BaseClass
    {
        public Category()
        {
            CategoryFilms = new List<CategoryFilm>();
        }
        public List<CategoryFilm> CategoryFilms { get; set; }
    }
}
