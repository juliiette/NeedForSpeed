using System;
using System.Collections.Generic;
using System.Timers;
using AutoMapper;
using Business.Abstract.Services;
using Business.Models;
using Data.Abstract;
using Data.Entity;

namespace Business.Implementation.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unit;
        
        private readonly IDetailService _detailService;

        private readonly List<DetailModel> _detailsUsed = new List<DetailModel>();

        private DetailModel _detail = new DetailModel();

        private int _distance = 0;

        
        public CarService(IDetailService detailService, IMapper mapper, IUnitOfWork unit)
        {
            _detailService = detailService;

            _mapper = mapper;
            _unit = unit;
        }


        public void Ride(CarModel car, PlayerModel player)
        {
            _detail = _detailService.ChooseRandomDetail(_detailsUsed);
            Timer timer = new Timer();
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

        private void OnTimerEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            _detailService.CrashDetail(_detail);
            _distance += 100;
        }

        
        public void CollectCar(CarModel car, PlayerModel player)
        {
            if (car.Motor != null && car.Battery != null && car.Rim != null)
            {
                car.CarRide = true;
                _detailsUsed.Add(car.Battery);
                _detailsUsed.Add(car.Motor);
                _detailsUsed.Add(car.Rim);
                Ride(car, player);
                
                UpdateEntity(car, player);
            }
        }

        public void CalculateIncome(int distance, PlayerModel player, CarModel car)
        {
            car.Distance += distance;

            int sum = distance * 3;

            player.Cash += sum;

            UpdateEntity(car, player);

        }

        public void UpdateEntity(CarModel carModel, PlayerModel playerModel)
        {
            var carEntity = _mapper.Map<Car>(carModel);
            var playerEntity = _mapper.Map<Player>(playerModel);
            
            _unit.CarRepository.Update(carEntity);
            _unit.PlayerRepository.Update(playerEntity);
        }
    }
}