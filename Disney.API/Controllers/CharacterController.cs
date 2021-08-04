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
    public class CharacterController : ControllerBase
    {
        #region Obj and Constructor
        private readonly ICharacterService IcharacterService;
        public CharacterController(ICharacterService IcharacterService)
        {
            this.IcharacterService = IcharacterService;
        }
        #endregion

        [HttpGet(Routes.Character.GetAllCharacters)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetAllCharacters()
        {
            var response = IcharacterService.GetAllCharacters();

            return Ok(await response);
        }

        [HttpGet(Routes.Character.GetCharacterByName)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<CharacterDTO> GetCharacterByName([FromQuery] string name)
        {
            var response = IcharacterService.GetCharacterByName(name);

            return Ok(response);
        }

        [HttpGet(Routes.Character.GetCharacterByAge)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<CharacterDTO> GetCharacterByAge([FromQuery] int age)
        {
            var response = IcharacterService.GetCharacterByAge(age);
            return Ok(response);
        }

        [HttpGet(Routes.Character.GetCharacterByMovieSerie)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<MovieSerieDTO> GetCharacterByMovieSerie([FromQuery] string movieserie)
        {
            var response = IcharacterService.GetCharacterByMovieSerie(movieserie);
            return Ok(response);
        }

        [HttpPost(Routes.Character.CreateCharacter)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> CreateCharacter([FromBody] CharacterDTO request)
        {
            var response = IcharacterService.CreateCharacter(request);

            return response.HasErrors
                ?BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpPut(Routes.Character.UpdateCharacter)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> UpdateCharacter([FromBody] CharacterDTO request)
        {
            var response = IcharacterService.UpdateCharacter(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }

        [HttpDelete(Routes.Character.DeleteCharacter)]
        [ProducesResponseType(typeof(Result), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 400)]
        [ProducesResponseType(typeof(UnauthorizedObjectResult), 401)]
        [ProducesResponseType(typeof(Result), 500)]
        [Authorize]
        public ActionResult<Result> DeleteCharacter([FromRoute] CharacterDTO request)
        {
            var response = IcharacterService.DeleteCharacter(request);

            return response.HasErrors
                ? BadRequest(response.Messages)
                : Ok(response);
        }
    }
}
