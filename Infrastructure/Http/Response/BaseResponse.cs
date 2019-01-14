using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Http.Response
{
    public class BaseResponse<T> : BaseResponse<T, ErrorResponse>
    {
        public BaseResponse()
        {
            Errors = new List<ErrorResponse>();
        }
        public BaseResponse(T data)
        {
            Data = data;
            Errors = new List<ErrorResponse>();
        }
    }

    public class BaseResponse<T, TError>
    {
        public BaseResponse()
        {
            Errors = new List<TError>();
        }

        public BaseResponse(T data)
        {
            Data = data;
            Errors = new List<TError>();
        }

        #region Members
        public int StatusCode { get; set; } = 200;
        public bool Success => !Errors.Any();
        public T Data { get; set; }
        public List<TError> Errors { get; set; }
        #endregion
    }
}
