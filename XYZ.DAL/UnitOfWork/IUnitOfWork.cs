using System;
using XYZ.DAL.Repository.Interfaces;

namespace XYZ.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
        void Dispose(bool disposing);

        TRepository Repository<TEntity, TRepository>() where TEntity : class
            where TRepository : IBaseRepository<TEntity>;
    }
}