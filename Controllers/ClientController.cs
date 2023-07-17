using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Event_Game.Services.EventServices;

namespace Web_Api_Event_Game.Controllers
{
    
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _eventService;
       
        public ClientController(IClientService eventService)
        {
            _eventService = eventService;
        }
        [HttpGet]
        [Route("api/GetAllClient")]
        public async Task<ActionResult<List<GetVoucherDTO>>> GetAllClient()
        {
            return Ok(await _eventService.GetAllClient());

        }
        [HttpGet]
        [Route("api/Client/{id}")]
        public async Task<ActionResult<GetClientDTO>> GetSingleClient(int id)
        {
            var result = await _eventService.GetSingleClient(id);
            if (result is null)
            {
                return NotFound("This Voucher is not found!!");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("api/CreateNewClient")]
        public async Task<ActionResult<List<GetClientDTO>>> AddClient(AddClientDTO NewClient)
        {
            var result = await _eventService.AddClient(NewClient);
            return Ok(result);
        }
        [HttpPut]
        [Route("api/Client/{id}")]
        public async Task<ActionResult<GetClientDTO>> UpdateClient(int id, AddClientDTO UpdateClient)
        {
            var result = await _eventService.UpdateClient(id, UpdateClient);
            if (result is null)
                return NotFound("Client not found.");

            return Ok(result);
        }
        [HttpDelete]
        [Route("api/Client/{id}")]
        public async Task<ActionResult<List<GetClientDTO>>> DeleteClient(int id)
        {
            var result = await _eventService.DeleteClient(id);
            if (result is null)
                return NotFound("Client not found.");

            return Ok(result);
        }
    }
}
