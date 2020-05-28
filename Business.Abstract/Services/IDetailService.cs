using System.Collections.Generic;
using Business.Models;
using Data.Entity;

namespace Business.Abstract.Services
{
    public interface IDetailService
    {
        IEnumerable<DetailModel> GetAll();

        IEnumerable<DetailModel> GetSpecial(DetailType type);

        void BuyDetail(DetailModel detail, CarModel car, PlayerModel player);

        void SellDetail(DetailModel detail, CarModel car, PlayerModel player);

        void CrashDetail(DetailModel detail, CarModel car);

        void RepairDetail(DetailModel detail, CarModel car, PlayerModel player);

        DetailModel ChooseRandomDetail(List<DetailModel> detailsUsed);
    }
}