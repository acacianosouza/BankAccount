using Application.DTO.Request;
using Application.DTO.Response;
using Infrastructure.Http.Response;

namespace Application.Contract
{
    public interface ITransactionApplication
    {
        BaseResponse<TransferResponse> Transfer(string userId, TransferRequest transferRequest);
    }
}
