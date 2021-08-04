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
    public class MovieSerieController : ControllerBase
    {
        #region Obj and Constructor
        private readonly IMovieSerieService ImovieSerieService;
        public MovieSerieController(IMovieSerieService ImovieSerieService)
        {
            this.ImovieSerieService = ImovieSerieService;
        }
        #endregion

        [HttpGet(Routes.MovieSerie.GetAllMoviesSeries)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<MovieSerieDTO>>> GetAllMoviesSeries()
        {
            var response = ImovieSerieService.GetAllMoviesSeries();

            return Ok(await response);
        }

        [HttpGet(Routes.MovieSerie.GetMovieSerieByName)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> GetMovieSerieByName([FromQuery] string name)
        {
            var response = ImovieSerieService.GetMovieSerieByName(name);

            return Ok(response);
        }

        [HttpGet(Routes.MovieSerie.GetMovieSerieByGenre)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<IEnumerable<GenreDTO>> GetMovieSerieByGenre([FromQuery] string genre)
        {
            var response = ImovieSerieService.GetMovieSerieByGenre(genre);

            return Ok(response);
        }

        [HttpGet(Routes.MovieSerie.GetMovieSerieByOrder)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<MovieSerieDTO>>> GetMovieSerieByOrder()
        {
            var response = ImovieSerieService.GetAllMoviesSeries();

            return Ok(await response);
        }

        [HttpPost(Routes.MovieSerie.CreateMovieSerie)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> CreateMovieSerie([FromBody] MovieSerieDTO request)
        {
            var response = ImovieSerieService.CreateMovieSerie(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpPut(Routes.MovieSerie.UpdateMovieSerie)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> UpdateMovieSerie([FromBody] MovieSerieDTO request)
        {
            var response = ImovieSerieService.UpdateMovieSerie(request);
            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpDelete(Routes.MovieSerie.DeleteMovieSerie)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> DeleteMovieSerie([FromRoute] MovieSerieDTO request)
        {
            var response = ImovieSerieService.DeleteMovieSerie(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }
    }
}
