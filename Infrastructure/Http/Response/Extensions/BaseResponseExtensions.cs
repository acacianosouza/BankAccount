using FluentValidation.Results;
using Infrastructure.Events;
using Infrastructure.Validator.Extensions;
using System.Collections.Generic;

namespace Infrastructure.Http.Response.Extensions
{
    public static class BaseResponseExtensions
    {
        #region Default Errors
        public static BaseResponse<TResponse> AddErrors<TResponse>(this BaseResponse<TResponse> baseResponse, IList<ValidationFailure> errors)
        {
            return baseResponse.AddErrors(errors.ToErrorResponse());
        }

        public static BaseResponse<TResponse> AddError<TResponse>(this BaseResponse<TResponse> baseResponse, ValidationFailure error)
        {
            return baseResponse.AddError(error.ToErrorResponse());
        }

        public static BaseResponse<TResponse> AddErrors<TResponse>(this BaseResponse<TResponse> baseResponse, IEnumerable<Event> errors)
        {
            return baseResponse.AddErrors(errors.ToErrorResponse());
        }

        public static BaseResponse<TResponse> AddError<TResponse>(this BaseResponse<TResponse> baseResponse, Event error)
        {
            return baseResponse.AddError(error.ToErrorResponse());
        }

        public static BaseResponse<TResponse> AddError<TResponse>(this BaseResponse<TResponse> baseResponse, ErrorResponse error)
        {
            baseResponse.Errors.Add(error);
            return baseResponse;
        }

        public static BaseResponse<TResponse> AddError<TResponse>(this BaseResponse<TResponse> baseResponse, int errorCode, string errorMessage)
        {
            baseResponse.Errors.Add(new ErrorResponse {
                Code = errorCode,
                Message = errorMessage
            });

            return baseResponse;
        }

        public static BaseResponse<TResponse> AddErrors<TResponse>(this BaseResponse<TResponse> baseResponse, IEnumerable<ErrorResponse> errors)
        {
            baseResponse.Errors.AddRange(errors);
            return baseResponse;
        }

        #endregion

        #region Custom Errors
        public static BaseResponse<TResponse, TError> AddErrors<TResponse, TError>(this BaseResponse<TResponse, TError> baseResponse, IList<ValidationFailure> errors) where TError : ErrorResponse
        {
            return baseResponse.AddErrors(errors.ToErrorResponse<TError>());
        }

        public static BaseResponse<TResponse, TError> AddError<TResponse, TError>(this BaseResponse<TResponse, TError> baseResponse, Event error) where TError : ErrorResponse
        {
            return baseResponse.AddError(error.ToErrorResponse<TError>());
        }

        public static BaseResponse<TResponse, TError> AddError<TResponse, TError>(this BaseResponse<TResponse, TError> baseResponse, TError error) where TError : ErrorResponse
        {
            baseResponse.Errors.Add(error);
            return baseResponse;
        }

        public static BaseResponse<TResponse, TError> AddErrors<TResponse, TError>(this BaseResponse<TResponse, TError> baseResponse, IEnumerable<TError> errors)
        {
            baseResponse.Errors.AddRange(errors);
            return baseResponse;
        }
        #endregion
    }
}
