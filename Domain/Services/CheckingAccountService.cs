using System;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services.Contracts;
using Domain.Validation;
using Infrastructure.Security;

namespace Domain.Services
{
    public class CheckingAccountService : ServiceBase<CheckingAccount> , ICheckingAccountService
    {
        private readonly ICheckingAccountRepository _checkingAccountRepository;

        public CheckingAccountService(ICheckingAccountRepository CheckingAccountRepository)
            : base(CheckingAccountRepository)
        {
            _checkingAccountRepository = CheckingAccountRepository;
        }

        public CheckingAccount GetByNumber(long number)
        {
            return _checkingAccountRepository.GetByNumber(number);
        }

        public CheckingAccount UpdateBalance(long number, decimal balance)
        {
            return _checkingAccountRepository.UpdateBalance(number, balance);
        }
    }
}
