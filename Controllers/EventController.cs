using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_Event_Game.Services.EventServices;

namespace Web_Api_Event_Game.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;


        //Event
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
       
        [HttpGet]
        [Route("api/Event")]
        public async Task<ActionResult<List<GetEventDTO>>> GetAllEvents()
        {
             return Ok(await _eventService.GetAllEvents());
            
        }
        [HttpGet]
        [Route("api/Event/{id}")]
        public async Task<ActionResult<GetEventDTO>> GetSingleEvent(int id)
        {
            var result = await _eventService.GetSingleEvent(id);
            if (result is null)
            {
                return NotFound("This Event is not found!!");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("api/Event")]
        public async Task<ActionResult<List<GetEventDTO>>> AddEvent(AddEventDTO NewEvent)
        {
            var result = await _eventService.AddEvent(NewEvent);
            return Ok(result);
        }
        [HttpPut]
        [Route("api/Event/{id}")]
        public async Task<ActionResult<GetEventDTO>> UpdateEvent(int id, AddEventDTO UpdateEvent)
        {
            var result = await _eventService.UpdateEvent(id, UpdateEvent);
            if (result is null)
                return NotFound("Event not found.");

            return Ok(result);
        }
        [HttpDelete]
        [Route("api/Event/{id}")]
        public async Task<ActionResult<List<GetEventDTO>>> DeleteEvent(int id)
        {
            var result = await _eventService.DeleteEvent(id);
            if (result is null)
                return NotFound("Event not found.");

            return Ok(result);
        }     

        //Add game to event
        [HttpPost]
        [Route("api/GameEvent")]
        public async Task<ActionResult<GetEventGameDTOcs>> AddGameToEvent(AddGameToEventDTO GameEvent)
        {
            var result = await _eventService.AddGameToEvent(GameEvent);
            if (result is null)
            {
                return NotFound("This Voucher is not found!!");
            }
            return Ok(result);
        }

        //get all table event game
        [HttpGet]
        [Route("api/GetAllGameEvent")]
        public async Task<ActionResult<List<EventGame>>> GetAllGameEvent()
        {
            var result = await _eventService.GetAllGameEvent();
            if (result is null)
            {
                return NotFound("This EventGame is not found!!");
            }
            return Ok(result);
        }
    }
}
