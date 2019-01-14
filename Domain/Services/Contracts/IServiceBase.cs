using Domain.Services.Contracts;

namespace Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IBase<TEntity> where TEntity : class
    {
        void Commit();
        void Rollback();
    }
}
