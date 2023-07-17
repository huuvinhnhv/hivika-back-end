using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Event_Game.Services.EventServices;
using Web_Api_Event_Game.Services.GameServices;

namespace Web_Api_Event_Game.Controllers
{
    
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameServices _eventService;


        //Event
        public GameController(IGameServices eventService)
        {
            _eventService = eventService;
        }
        //Game
        [HttpGet]
        [Route("api/GetAllGame")]
        public async Task<ActionResult<List<GetGameDTO>>> GetAllGame()
        {
            return Ok(await _eventService.GetAllGame());

        }
        [HttpGet]
        [Route("api/Game/{id}")]
        public async Task<ActionResult<GetGameDTO>> GetSingleGame(int id)
        {
            var result = await _eventService.GetSingleGame(id);
            if (result is null)
            {
                return NotFound("This Game is not found!!");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("api/Game")]
        public async Task<ActionResult<List<GetGameDTO>>> AddGame(AddGameDTO NewEvent)
        {
            var result = await _eventService.AddGame(NewEvent);
            return Ok(result);
        }
        [HttpPut]
        [Route("api/Game/{id}")]
        public async Task<ActionResult<GetGameDTO>> UpdateGame(int id, AddGameDTO UpdateEvent)
        {
            var result = await _eventService.UpdateGame(id, UpdateEvent);
            if (result is null)
                return NotFound("Game not found.");

            return Ok(result);
        }
        [HttpDelete]
        [Route("api/Game/{id}")]
        public async Task<ActionResult<List<GetGameDTO>>> DeleteGame(int id)
        {
            var result = await _eventService.DeleteGame(id);
            if (result is null)
                return NotFound("Game not found.");

            return Ok(result);
        }

    }
}
