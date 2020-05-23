using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Models;
using Business.Abstract;
using Business.Abstract.Services;
using Data.Abstract;
using Data.Entity;

namespace Business.Implementation.Services
{
    public class DetailService : IDetailService
    {

        private readonly IPlayerService _playerService;

        private readonly IUnitOfWork _unit;

        private readonly IMapper _mapper;

        public DetailService(IPlayerService playerService, IUnitOfWork unit, IMapper mapper)
        {
            _playerService = playerService;

            _unit = unit;
            _mapper = mapper;
        }
        
        
        public void BuyDetail(DetailModel detail, CarModel car, PlayerModel player)
        {
            if (_playerService.CheckCash(player, detail.RetailCost))
            {
                switch (detail.DetailType)
                {
                    case DetailTypeModel.Battery:
                        car.Battery = detail;
                        break;
                    
                    case DetailTypeModel.Motor:
                        car.Motor = detail;
                        break;
                    
                    case DetailTypeModel.Rim:
                        car.Rim = detail;
                        break;
                }

                player.Cash -= detail.RetailCost;
            }
            // do exception
        }

        
        public void SellDetail(DetailModel detail, CarModel car, PlayerModel player)
        {
            switch (detail.DetailType)
            {
                case DetailTypeModel.Battery:
                    car.Battery = null;
                    break;
                    
                case DetailTypeModel.Motor:
                    car.Motor = null;
                    break;
                    
                case DetailTypeModel.Rim:
                    car.Rim = null;
                    break;
            }

            player.Cash += detail.RepairCost;
        }

        
        public void CrashDetail(DetailModel detail, CarModel car)
        {
            if (detail.Stability <= 0.2)
            {
                detail.CanFunction = false;
                car.CarRide = false;
            }
            else
            {
                var random = new Random();

                double propability = 1 - detail.Stability;
                
                if (random.NextDouble() < propability)
                {
                    detail.CanFunction = false;
                    car.CarRide = false;
                }
            }
        }

        
        public void RepairDetail(DetailModel detail, CarModel car, PlayerModel player)
        {
            if (detail.Stability <= 0.2)
            {
                detail.CanFunction = false;
                car.CarRide = false;
            }
            else
            {
                if (_playerService.CheckCash(player, detail.RepairCost))
                {
                    double coef = (1 - detail.Stability) / 4;
                
                    detail.Stability = detail.Stability - coef;
                
                    player.Cash -= detail.RepairCost;
                
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

        public IEnumerable<DetailModel> GetSpecial(DetailTypeModel type)
        {
            var specialDetails = GetAll().Where((Func<DetailModel, bool>)(d => d.DetailType == type));

            return _mapper.Map<IEnumerable<DetailModel>>(specialDetails);
        }  
    }
}