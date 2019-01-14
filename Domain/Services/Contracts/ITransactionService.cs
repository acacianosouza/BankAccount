using System.Collections.Generic;
using Domain.Entities;
using Domain.Interfaces.Services;
using Domain.Validation;

namespace Domain.Services.Contracts
{
    public interface ITransactionService : IServiceBase<Transaction>
    {
    }
}
