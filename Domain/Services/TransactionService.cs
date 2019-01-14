using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services.Contracts;
using Domain.Validation;
using Domain.Validation.User;
using Infrastructure.Security;

namespace Domain.Services
{
    public class TransactionService : ServiceBase<Transaction>, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
            : base(transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
    }
}
