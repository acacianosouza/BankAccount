using Infrastructure.Http.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        public IActionResult BaseResponse<T>(BaseResponse<T> response)
        {
            if (response.Errors != null && response.Errors.Any())
            {
                response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return UnprocessableEntity(response);
            }

            if (response.StatusCode == 204)
                return NoContent();
            else
                return StatusCode(response.StatusCode, response);
        }

        public IActionResult BaseResponse<T, TError>(BaseResponse<T, TError> response)
        {
            if (response.Errors != null && response.Errors.Any())
            {
                response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                return UnprocessableEntity(response);
            }

            return StatusCode(response.StatusCode, response);
        }
    }
}
