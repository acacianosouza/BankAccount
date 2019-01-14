using Domain.Interfaces.UnitOfWork;
using Domain.Services.Contracts;

namespace Domain.Repository
{
    public interface IRepositoryBase<TEntity> : IUnitOfWork, IBase<TEntity> where TEntity : class
    {
    }
}
