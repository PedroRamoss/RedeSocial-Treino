using Microsoft.AspNetCore.Mvc;
using RedeSocial.Application.Services;

namespace RedeSocial.Api.Controllers.BaseController
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        protected IActionResult HandleFailure(Result result)
        {
            if (result.Error == null)
                return StatusCode(500, "An unknown error occurred.");

            var errorDescription = new { error = result.Error.Description };

            return result.Error.Type switch
            {
                ErrorType.NotFound => NotFound(errorDescription),
                ErrorType.Unauthorized => Unauthorized(errorDescription),
                ErrorType.BadRequest => BadRequest(errorDescription),
                ErrorType.UnprocessableEntity => UnprocessableEntity(errorDescription),
                ErrorType.Forbbiden => Forbid(result.Error.Description),
                _ => StatusCode(500, errorDescription)
            };
        }
    }
}
