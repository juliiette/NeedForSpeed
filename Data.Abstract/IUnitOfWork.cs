using Data.Entity;
using System;

namespace Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IDetailRepository DetailRepository { get; }

        ICarRepository CarRepository { get; }

        IPlayerRepository PlayerRepository { get; }

        void Save();

    }
}