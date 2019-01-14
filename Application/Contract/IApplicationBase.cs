using Domain.Services.Contracts;

namespace Application.Contract
{
    public interface IApplicationBase<TEntity> : IBase<TEntity> where TEntity : class
    {
        void Commit();
        void Rollback();
    }
}
