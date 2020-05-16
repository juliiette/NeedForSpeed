using AutoMapper;
using Business.Models;
using Data.Entity;

namespace Business.Implementation.Mapper
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            CreateMap<Detail, DetailModel>().ReverseMap();

            CreateMap<Car, CarModel>().ReverseMap();

            CreateMap<Player, PlayerModel>().ReverseMap();
        }
    }
}