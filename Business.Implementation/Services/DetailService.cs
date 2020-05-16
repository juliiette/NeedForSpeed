using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Models;
using Business.Abstract;
using Business.Abstract.Services;
using Data.Abstract;

namespace Business.Implementation.Services
{
    public class DetailService : IDetailService
    {
        private readonly CarModel _car;

        private readonly PlayerModel _player;

        private readonly IPlayerService _playerService;

        private readonly IUnitOfWork _unit;

        private readonly IMapper _mapper;

        public DetailService(CarModel car, PlayerModel player, IPlayerService playerService, IUnitOfWork unit, IMapper mapper)
        {
            _car = car;
            _player = player;
            _playerService = playerService;

            _unit = unit;
            _mapper = mapper;
        }
        
        
        public void BuyDetail(DetailModel detail)
        {
            if (_playerService.CheckCash(_player, detail.RetailCost))
            {
                switch (detail.DetailType)
                {
                    case DetailType.Battery:
                        _car.Battery = detail;
                        break;
                    
                    case DetailType.Motor:
                        _car.Motor = detail;
                        break;
                    
                    case DetailType.Rim:
                        _car.Rim = detail;
                        break;
                }

                _player.Cash -= detail.RetailCost;
            }
            // do exception
        }

        
        public void SellDetail(DetailModel detail)
        {
            switch (detail.DetailType)
            {
                case DetailType.Battery:
                    _car.Battery = null;
                    break;
                    
                case DetailType.Motor:
                    _car.Motor = null;
                    break;
                    
                case DetailType.Rim:
                    _car.Rim = null;
                    break;
            }

            _player.Cash += detail.RepairCost;
        }

        
        public void CrashDetail(DetailModel detail)
        {
            if (detail.Stability <= 0.2)
            {
                detail.CanFunction = false;
                _car.CarRide = false;
            }
            else
            {
                var random = new Random();

                double propability = 1 - detail.Stability;
                
                if (random.NextDouble() < propability)
                {
                    detail.CanFunction = false;
                    _car.CarRide = false;
                }
            }
        }

        
        public void RepairDetail(DetailModel detail)
        {
            if (detail.Stability <= 0.2)
            {
                detail.CanFunction = false;
                _car.CarRide = false;
            }
            else
            {
                if (_playerService.CheckCash(_player, detail.RepairCost))
                {
                    double coef = (1 - detail.Stability) / 4;
                
                    detail.Stability = detail.Stability - coef;
                
                    _player.Cash -= detail.RepairCost;
                
                    detail.RepairCost = detail.RepairCost + 20;
                
                    detail.CanFunction = true;
                }
            }
        }

        public DetailModel ChooseRandomDetail(List<DetailModel> detailsUsed)
        {
            var rand = new Random();
            DetailModel randDetail;

            randDetail = detailsUsed[rand.Next(detailsUsed.Count)];

            return randDetail;
        }


        public IEnumerable<DetailModel> GetAll()
        {
            var details = _unit.DetailRepository.GetAll();

            return _mapper.Map<IEnumerable<DetailModel>>(details);
        }

        public IEnumerable<DetailModel> GetSpecial(DetailType type)
        {
            var specialDetails = GetAll().Where(d => d.DetailType == type);

            return _mapper.Map<IEnumerable<DetailModel>>(specialDetails);
        }
        
        
    }
}