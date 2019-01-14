using Application.Contract;
using Application.DTO.Request;
using Infrastructure.Claims.Extension;
using Infrastructure.Http.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers.Front
{
    public class TransactionController : BaseController
    {
        #region Dependencies
        private readonly ITransactionApplication transactionApplication;
        #endregion

        public TransactionController(ITransactionApplication transactionApplication)
        {
            this.transactionApplication = transactionApplication;
        }

        [HttpPost("transfer")]
        public IActionResult Transfer([FromBody]TransferRequest request)
        {
            return BaseResponse(this.transactionApplication.Transfer(HttpContext.User.UserId(), request));
        }
    }
}