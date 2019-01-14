using System.Collections.Generic;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.Repository;

namespace Domain.Interfaces.Repositories
{
    public interface ITransactionRepository : IRepositoryBase<Transaction>
    {
        void Add(Transaction transaction);
    }
}
