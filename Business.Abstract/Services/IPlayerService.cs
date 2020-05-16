using System.Collections.Generic;
using Business.Models;

namespace Business.Abstract.Services
{
    public interface IPlayerService
    {
        bool CheckCash(PlayerModel playerModel, int sum);

        IEnumerable<PlayerModel> GetAll();
    }
}