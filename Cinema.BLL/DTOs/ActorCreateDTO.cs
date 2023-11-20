using Cinema.Core.Entities;
using Cinema.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.DTOs
{
    public class ActorCreateDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int AwardCount { get; set; }
        public List<FilmCategoriesDTO> ActorFilmList{ get; set; }

    }
}
