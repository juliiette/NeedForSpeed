using AutoMapper;
using Business.Models;
using Data.Abstract;
using Data.Entity;
using Business.Abstract.Services;

namespace Business.Implementation.Mapper
{
    public class MappingService : IMappingService
    {
        private IUnitOfWork unitOfWork;

        public MappingService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public DetailModel Map(Detail detail)
        {
            return new DetailModel
            {
                Id = detail.Id,
                Name = detail.Name,
                DetailType = detail.DetailType,
                RetailCost = detail.RetailCost,
                RepairCost = detail.RepairCost,
                Stability = detail.Stability,
                CanFunction = detail.CanFunction
            };
        }
        public Detail Map(DetailModel detailModel)
        {
            Detail detail;
            if (detailModel.Id > 0)
                detail = unitOfWork.DetailRepository.GetById(detailModel.Id);
            else
                detail = new Detail();

            detail.Id = detailModel.Id;
            detail.Name = detailModel.Name;
            detail.DetailType = detailModel.DetailType;
            detail.RetailCost = detailModel.RetailCost;
            detail.RepairCost = detailModel.RepairCost;
            detail.Stability = detailModel.Stability;
            detail.CanFunction = detailModel.CanFunction;

            return detail;
        }

        //public DetailTypeModel Map(DetailType detailType)
        //{
        //    return new DetailTypeModel
        //    {
                
        //    };
        //}
    }
}
