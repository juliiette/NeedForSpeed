using System.Collections;
using System.Collections.Generic;
using Business.Models;

namespace Business.Abstract.Services
{
    public interface IDetailService
    {
        IEnumerable<DetailModel> GetAll();

        IEnumerable<DetailModel> GetSpecial(DetailType type);
        
        void BuyDetail(DetailModel detail);

        void SellDetail(DetailModel detail);

        void CrashDetail(DetailModel detail);

        void RepairDetail(DetailModel detail);

        DetailModel ChooseRandomDetail(List<DetailModel> detailsUsed);
    }
}