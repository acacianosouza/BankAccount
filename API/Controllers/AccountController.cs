using System.Threading.Tasks;
using API.Controllers;
using Application.Contract;
using Application.DTO.Request;
using Infrastructure.Claims.Extension;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AccountController : BaseController
    {
        #region Dependencies
        private readonly ITransactionApplication checkingAccountApplication;
        #endregion

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(HttpContext.User.UserName());
        }
    }
}