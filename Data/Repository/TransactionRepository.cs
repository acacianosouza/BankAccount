using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;

namespace Data.Repository
{
    public class TransactionRepository : RepositoryBase<Transaction>, ITransactionRepository
    {
        public TransactionRepository(SuperDigitalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
