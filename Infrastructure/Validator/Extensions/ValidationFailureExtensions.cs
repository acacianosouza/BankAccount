using FluentValidation.Results;
using Infrastructure.Http.Response;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Validator.Extensions
{
    public static class ValidationFailureExtensions
    {
        public static IEnumerable<ErrorResponse> ToErrorResponse(this IList<ValidationFailure> validationFailures)
        {
            return validationFailures.Select(validationFailure => validationFailure.ToErrorResponse());
        }

        public static ErrorResponse ToErrorResponse(this ValidationFailure validationFailure)
        {
            int errorCode = 0;
            int.TryParse(validationFailure.ErrorCode, out errorCode);
            return new ErrorResponse { Code = errorCode, Message = validationFailure.ErrorMessage };
        }

        public static IEnumerable<TError> ToErrorResponse<TError>(this IList<ValidationFailure> validationFailures) where TError : ErrorResponse
        {
            return validationFailures.Select(validationFailure => validationFailure.ToErrorResponse<TError>());
        }

        public static TError ToErrorResponse<TError>(this ValidationFailure validationFailure) where TError : ErrorResponse
        {
            int errorCode = 0;
            int.TryParse(validationFailure.ErrorCode, out errorCode);

            var error = default(TError);
            error.Code = errorCode;
            error.Message = validationFailure.ErrorMessage;
            return error;
        }
    }
}
