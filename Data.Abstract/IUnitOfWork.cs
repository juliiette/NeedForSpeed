using Data.Entity;
using System;

namespace Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<int, Detail> DetailRepository { get; }

        IRepository<int, Car> CarRepository { get; }

        IRepository<int, Player> PlayerRepository { get; }

        void Save();

    }
}