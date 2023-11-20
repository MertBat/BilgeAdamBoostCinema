using AutoMapper;
using Cinema.BLL.DTOs;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.BLL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Film,FilmCreateDTO>().ReverseMap();
            CreateMap<Film, FilmUpdateDTO>().ReverseMap();
            CreateMap<Actor, ActorCreateDTO>().ReverseMap();
            CreateMap<Actor, ActorUpdateDTO>().ReverseMap();
        }
    }
}
