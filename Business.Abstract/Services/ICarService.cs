using Business.Models;

namespace Business.Abstract.Services
{
    public interface ICarService
    {

        void Ride();

        void CollectCar();

        void CalculateIncome(int distance);
    }
}