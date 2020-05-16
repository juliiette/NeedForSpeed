using System;
using Business.Models;

namespace Business.Abstract.Services
{
    public interface ICarService
    {

        void Ride(CarModel carModel, PlayerModel playerModel);

        void CollectCar(CarModel carModel, PlayerModel playerModel);

        void CalculateIncome(int distance, PlayerModel playerModel, CarModel carModel);

        void UpdateEntity(CarModel carModel, PlayerModel playerModel);
    }
}