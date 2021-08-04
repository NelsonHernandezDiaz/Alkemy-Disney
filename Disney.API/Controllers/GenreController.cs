using Disney.API.Common;
using Disney.Application.Interfaces;
using Disney.Domain.Common;
using Disney.Domain.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Disney.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        #region Obj and Constructor
        private readonly IGenreService IgenreService;
        public GenreController(IGenreService IgenreService)
        {
            this.IgenreService = IgenreService;
        }
        #endregion

        [HttpGet(Routes.Genre.GetAllGenres)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAllGenres()
        {
            var response = IgenreService.GetAllGenres();

            return Ok(await response);
        }
        
        [HttpPost(Routes.Genre.CreateGenre)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> CreateGenre([FromBody] GenreDTO request)
        {
            var response = IgenreService.CreateGenre(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpPut(Routes.Genre.UpdateGenre)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> UpdateGenre([FromBody] GenreDTO request)
        {
            var response = IgenreService.UpdateGenre(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpDelete(Routes.Genre.DeleteGenre)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> DeleteGenre([FromRoute] GenreDTO request)
        {
            var response = IgenreService.DeleteGenre(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }
    }
}
