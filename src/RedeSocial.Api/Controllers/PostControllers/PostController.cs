using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Api.Controllers.BaseController;
using RedeSocial.Api.Controllers.PostControllers.Request;
using RedeSocial.Api.Controllers.UserControllers.Request;
using RedeSocial.Api.Mappers;
using RedeSocial.Application.Services.Interfaces;

namespace RedeSocial.Api.Controllers.PostControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ApiControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [Authorize]
        [HttpPost("create-post")]
        public async Task<IActionResult> CreateAccountAsync([FromBody] CreatePostRequest post, CancellationToken cancellationToken)
        {
            var result = await _postService.CreatePostAsync(post.ToDomain(), cancellationToken);

            if (!result.IsSuccess)
                return HandleFailure(result);

            return Ok(result);
        }

        //[Authorize]
        //[HttpPatch("update-post")]
        //public async Task<IActionResult> UpdateAccountAsync([FromHeader] Guid id, [FromBody] UserUpdateRequest user)
        //{
        //    var result = await _userService.UpdateUserAsync(id, user);

        //    if (!result.IsSuccess)
        //        return HandleFailure(result);

        //    return Ok(result.Response);
        //}

    }
}
