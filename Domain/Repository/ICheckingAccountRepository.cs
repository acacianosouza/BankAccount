using System.Collections.Generic;
using Domain.Interfaces.Repositories;
using Domain.Entities;
using Domain.Repository;
using System;

namespace Domain.Interfaces.Repositories
{
    public interface ICheckingAccountRepository : IRepositoryBase<CheckingAccount>
    {
        CheckingAccount GetByNumber(long number);
        CheckingAccount UpdateBalance(long number, decimal balance);
    }
}
