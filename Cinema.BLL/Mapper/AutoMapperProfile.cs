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
            CreateMap<Actor, ActorCreateDTO>().ForMember(dest => dest.ActorFilmList, opt => opt.MapFrom(src => src.ActorFilms.Select(af => new FilmCategoriesDTO { Id = af.FilmId, Name = af.Film.Name })));
            CreateMap<Actor, ActorUpdateDTO>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTO>().ReverseMap();
            CreateMap<Category, CategoryCreateDTO>().ForMember(dest => dest.CategoryFilmList, opt => opt.MapFrom(src => src.CategoryFilms.Select(af => new FilmCategoriesDTO { Id=af.FilmId, Name=af.Film.Name })));
        }
    }
}
