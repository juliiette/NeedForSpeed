using System.Collections.Generic;
using System.Timers;
using AutoMapper;
using Business.Abstract.Services;
using Business.Models;
using Data.Abstract;
using Data.Entity;
using Business.Implementation.Mapper;

namespace Business.Implementation.Services
{
    public class CarService : ICarService
    {
        private readonly IDetailService _detailService;

        private readonly List<DetailModel> _detailsUsed = new List<DetailModel>();
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        private CarModel _car;
        private DetailModel _detail = new DetailModel();
        private int _distance;


        public CarService(IDetailService detailService, IMapper mapper, IUnitOfWork unit)
        {
            _detailService = detailService;
            _mapper = mapper;
            _unit = unit;
        }


        public void Ride(CarModel car, PlayerModel player)
        {
            _car = car;
            _detail = _detailService.ChooseRandomDetail(_detailsUsed);
            var timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += OnTimerEvent;
            timer.AutoReset = true;

            do
            {
                timer.Enabled = true;

                timer.Start();
            } while (car.CarRide);

            timer.Stop();

            CalculateIncome(_distance, player, car);
            _distance = 0;

            UpdateEntity(car, player);
        }


        public void CollectCar(CarModel car, PlayerModel player)
        {
            _detailsUsed.Clear();
            if (car.Motor != null && car.Battery != null && car.Rim != null)
            {
                //car.CarRide = true;
                _detailsUsed.Add(car.Battery);
                _detailsUsed.Add(car.Motor);
                _detailsUsed.Add(car.Rim);

                int costil = 0;
                foreach (var detail in _detailsUsed)
                {
                    if (detail.CanFunction == false)
                    {
                        costil += 1;
                    }
                }

                if (costil == 0)
                {
                    car.CarRide = true;
                    Ride(car, player);
                    UpdateEntity(car, player);
                }
            }
        }

        public void CalculateIncome(int distance, PlayerModel player, CarModel car)
        {
            car.Distance += distance;

            var sum = distance * 3;

            player.Cash += sum;

           UpdateEntity(car, player);
        }

        public void UpdateEntity(CarModel carModel, PlayerModel playerModel)
        {
            var carEntity = _mapper.Map<Car>(carModel);
            var playerEntity = _mapper.Map<Player>(playerModel);

            var motor = _mapper.Map<Detail>(carModel.Motor);
            var battery = _mapper.Map<Detail>(carModel.Battery);
            var rim = _mapper.Map<Detail>(carModel.Rim);

            //_unit.DetailRepository.Update(motor);
            //_unit.DetailRepository.Update(battery);
            //_unit.DetailRepository.Update(rim);
            _unit.CarRepository.Update(carEntity);
            _unit.PlayerRepository.Update(playerEntity);

        }

        private void OnTimerEvent(object source, ElapsedEventArgs e)
        {
            _detailService.CrashDetail(_detail, _car);
            _distance += 100;
        }
    }
}