using Application.DTO.Request;
using Domain.Interfaces.Repositories;
using Domain.Services.Contracts;
using FluentValidation;

namespace Application.Validation.Request
{
    public class TransferValidator : AbstractValidator<TransferRequest>
    {
        public TransferValidator(ICheckingAccountService checkingAccountService)
        {
            RuleFor(transfer => transfer.NumberFrom)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .Must(number => number > 0)
                .WithMessage("Número de conta origem inválido");

            RuleFor(transfer => transfer.NumberTo)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .Must(number => number > 0)
                .WithMessage("Número de conta destino inválido");

            RuleFor(transfer => transfer.NumberFrom)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(t => t.NumberTo)
                .WithMessage("Conta origem e conta destino devem ser diferentes");

            RuleFor(transfer => transfer.Amount)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .Must(number => number > 0)
                .WithMessage("Valor de transferência deve ser maior que zero");

            RuleFor(transfer => transfer)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom((transfer, context) =>
                {
                    var checkingAccountFrom = checkingAccountService.GetByNumber(transfer.NumberFrom);
                    if (checkingAccountFrom == null)
                        context.AddFailure("Conta origem não encontrada");
                    if (checkingAccountFrom.UserId.ToString() != transfer.UserId)
                        context.AddFailure("Conta origem não pertence ao usuário logado");
                });

            RuleFor(transfer => transfer)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Custom((transfer, context) =>
                {
                    var checkingAccountFrom = checkingAccountService.GetByNumber(transfer.NumberTo);
                    if (checkingAccountFrom == null)
                        context.AddFailure("Conta destino não encontrada");
                });
        }
    }
}
