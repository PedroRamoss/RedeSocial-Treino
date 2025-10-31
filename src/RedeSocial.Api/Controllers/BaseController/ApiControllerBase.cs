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

            return result.Error.Type switch
            {
                ErrorType.NotFound => NotFound(result.Error.Description),
                ErrorType.Unauthorized => Unauthorized(result.Error.Description),
                ErrorType.BadRequest => BadRequest(result.Error.Description),
                ErrorType.UnprocessableEntity => UnprocessableEntity(result.Error.Description),
                ErrorType.Forbbiden => Forbid(result.Error.Description),
                _ => StatusCode(500, result.Error.Description)
            };
        }
    }
}
