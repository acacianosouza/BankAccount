using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Validation;

namespace Domain.Services.Contracts
{
    public interface ICheckingAccountService : IServiceBase<CheckingAccount>
    {
        CheckingAccount GetByNumber(long number);
        CheckingAccount UpdateBalance(long number, decimal amount);
    }
}
