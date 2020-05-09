using Business.Models;

namespace Business.Abstract.Services
{
    public interface IPlayerService
    {
        bool CheckCash(PlayerModel playerModel, int sum);
    }
}