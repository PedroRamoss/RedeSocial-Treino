using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Api.Controllers.BaseController;
using RedeSocial.Api.Controllers.UserControllers.Request;
using RedeSocial.Api.Mappers;
using RedeSocial.Application.Services.Interfaces;

namespace RedeSocial.Api.Controllers.UserControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLoginRequest user)
        {
            var result = await _userService.LoginAsync(user.UserName, user.Password);

            if (!result.IsSuccess)
                return HandleFailure(result);

            return Ok(result);
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> CreateAccountAsync([FromBody] CreateUserRequest user)
        {
            var result = await _userService.CreateUserAsync(user.ToDomain());

            if (!result.IsSuccess)
                return HandleFailure(result);

            return Ok(result);
        }

        [Authorize]
        [HttpPatch("update-account")]
        public async Task<IActionResult> UpdateAccountAsync([FromHeader] Guid id, [FromBody] UserUpdateRequest user)
        {
            var result = await _userService.UpdateUserAsync(id, user);

            if (!result.IsSuccess)
                return HandleFailure(result);

            return Ok(result.Response);
        }
    }

}
