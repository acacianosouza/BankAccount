using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;

namespace Data.Repository
{
    public class CheckingAccountRepository : RepositoryBase<CheckingAccount> , ICheckingAccountRepository
    {
        public SuperDigitalDbContext dbContext;

        public CheckingAccountRepository(SuperDigitalDbContext dbContext) : base(dbContext)
        {
        }

        public CheckingAccount GetByNumber(long number)
        {
            return DbSet.FirstOrDefault(x => x.Number == number && x.Active);
        }

        public CheckingAccount UpdateBalance(long number, decimal balance)
        {
            var current = DbSet.FirstOrDefault(x => x.Number == number && x.Active);
            current.Balance += balance;

            Update(current);

            return current;
        }
    }
}
