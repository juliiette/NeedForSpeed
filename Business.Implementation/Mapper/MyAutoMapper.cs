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

            CreateMap<DetailType, DetailTypeModel>().ReverseMap();

            CreateMap<Car, CarModel>();
            CreateMap<CarModel, Car>()
                .ForMember(car => car.BatteryId, cfg => cfg.MapFrom(carModel => carModel.Battery.Id))
                .ForMember(car => car.Battery, cfg => cfg.Ignore())

                .ForMember(car => car.MotorId, cfg => cfg.MapFrom(carModel => carModel.Motor.Id))
                .ForMember(car => car.Motor, cfg => cfg.Ignore())

                .ForMember(car => car.RimId, cfg => cfg.MapFrom(carModel => carModel.Rim.Id))
                .ForMember(car => car.Rim, cfg => cfg.Ignore());


            CreateMap<Player, PlayerModel>().ReverseMap();


        }
    }
}