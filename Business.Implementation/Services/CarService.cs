using System;
using System.Collections.Generic;
using System.Timers;
using AutoMapper;
using Business.Abstract.Services;
using Business.Models;
using Data.Abstract;

namespace Business.Implementation.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unit;
        
        private readonly CarModel _car;

        private readonly PlayerModel _player;

        private readonly IDetailService _detailService;

        private readonly List<DetailModel> _detailsUsed = new List<DetailModel>();

        private DetailModel _detail = new DetailModel();

        private int _distance = 0;

        
        public CarService(CarModel car, PlayerModel player, IDetailService detailService, IMapper mapper, IUnitOfWork unit)
        {
            _car = car;
            _player = player;
            _detailService = detailService;

            _mapper = mapper;
            _unit = unit;
        }


        public void Ride()
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
                
            } while (_car.CarRide);
            
            timer.Stop();
            
            CalculateIncome(_distance);
            _distance = 0;
        }

        private void OnTimerEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            _detailService.CrashDetail(_detail);
            _distance += 100;
        }

        
        public void CollectCar()
        {
            if (_car.Motor != null && _car.Battery != null && _car.Rim != null)
            {
                _car.CarRide = true;
                _detailsUsed.Add(_car.Battery);
                _detailsUsed.Add(_car.Motor);
                _detailsUsed.Add(_car.Rim);
                Ride();
            }
        }

        public void CalculateIncome(int distance)
        {
            _car.Distance += distance;

            int sum = distance * 3;

            _player.Cash += sum;
        }
    }
}