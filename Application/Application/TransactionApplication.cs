using Application.Contract;
using Application.DTO.Request;
using Application.DTO.Response;
using Application.Validation;
using Application.Validation.Request;
using Domain.Entities;
using Domain.Services.Contracts;
using Domain.Validation;
using Infrastructure.Http.Response;
using Infrastructure.Http.Response.Extensions;
using System;
using FluentValidation.Results;

namespace Application.Application
{
    public class TransactionApplication : ITransactionApplication
    {
        private readonly ICheckingAccountService _checkingAccountService;
        private readonly ITransactionService _transactionService;

        public TransactionApplication(ICheckingAccountService checkingAccountService, ITransactionService transactionService)
        {
            _checkingAccountService = checkingAccountService;
            _transactionService = transactionService;
        }

        public BaseResponse<TransferResponse> Transfer(string userId, TransferRequest transferRequest)
        {
            var response = new BaseResponse<TransferResponse>();

            try
            {
                transferRequest.UserId = userId;
                TransferValidator transferValidator = new TransferValidator(_checkingAccountService);
                FluentValidation.Results.ValidationResult validationResult = transferValidator.Validate(transferRequest);

                if (!validationResult.IsValid)
                {
                    response.AddErrors(validationResult.Errors);
                    return response;
                }

                var from = _checkingAccountService.UpdateBalance(transferRequest.NumberFrom, transferRequest.Amount * -1);
                var to = _checkingAccountService.UpdateBalance(transferRequest.NumberTo, transferRequest.Amount);

                _transactionService.Add(new Transaction
                {
                    Amount = transferRequest.Amount,
                    FromCheckingAccountId = from.Id,
                    ToCheckingAccountId = to.Id
                });

                _checkingAccountService.Commit();

                response.Data = new TransferResponse { Balance = from.Balance };
            }
            catch (Exception ex)
            {
                _checkingAccountService.Rollback();
                response.AddError(1, "Erro inesperado");
            }
            return response;
        }
    }
}