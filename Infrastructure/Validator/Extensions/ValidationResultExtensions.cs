using FluentValidation.Results;
using Infrastructure.Http.Response;
using System.Linq;

namespace Infrastructure.Validator.Extensions
{
    public static class ValidationResultExtensions
    {
        public static BaseResponse<bool> ToBaseResponse<T>(this ValidationResult result)
        {
            if (!result.IsValid)
            {
                return new BaseResponse<bool>
                {
                    Data = false,
                    Errors = result.Errors.ToErrorResponse().ToList()
                };
            }
            else
            {
                return null;
            }
        }
    }
}
