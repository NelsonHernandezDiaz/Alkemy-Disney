using Disney.API.Common;
using Disney.Application.Auth;
using Disney.Application.Commands;
using Disney.Application.Extensions;
using Disney.Application.Interfaces;
using Disney.Application.Models;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.API
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region Obj and Constructor
        private readonly IUserService IuserService;
        private readonly IEmailService IemailService;

        public UserController(IUserService IuserService, IEmailService IemailService)
        {
            this.IuserService = IuserService;
            this.IemailService = IemailService;
        }
        #endregion

        [HttpGet(Routes.User.GetAllUsers)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var response = IuserService.GetAllUsers();

            return Ok(await response);
        }

        [HttpPost(Routes.User.Login)]
        [ProducesResponseType(typeof(AuthenticationResult), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromBody] LoginUser request)
        {
            var response = await IuserService.LoginUser(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpPost(Routes.User.Register)]
        [ProducesResponseType(typeof(AuthenticationResult), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUser request)
        {
            var response = await IuserService.RegisterUser(request);

            return (response.HasErrors)
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpDelete(Routes.User.Delete)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromRoute] DeleteUser request)
        {
            request.SetUser(User.GetUserId());
            var response = await IuserService.DeleteUser(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpPost(Routes.User.SendMail)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public async Task<ActionResult> SendMail([FromRoute] EmailInfo email)
        {
            var response = IemailService.SendMail(email);

            return Ok(response);
        }
    }
}
