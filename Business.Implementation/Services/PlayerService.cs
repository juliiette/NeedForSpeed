using System.Collections.Generic;
using AutoMapper;
using Business.Abstract.Services;
using Business.Models;
using Data.Abstract;

namespace Business.Implementation.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public PlayerService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public bool CheckCash(PlayerModel playerModel, int sum)
        {
            var isEnough = playerModel.Cash > sum;

            return isEnough;
        }

        public IEnumerable<PlayerModel> GetAll()
        {
            var players = _unit.PlayerRepository.GetAll();

            return _mapper.Map<IEnumerable<PlayerModel>>(players);
        }
    }
}