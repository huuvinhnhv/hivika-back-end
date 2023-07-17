using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_Event_Game.Services.EventServices;

namespace Web_Api_Event_Game.Controllers
{
    
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherService _eventService;


        //Event
        public VoucherController(IVoucherService eventService)
        {
            _eventService = eventService;
        }
        //Voucher
        [HttpGet]
        [Route("api/GetAllVoucher")]
        public async Task<ActionResult<List<GetVoucherDTO>>> GetAllVoucher()
        {
            return Ok(await _eventService.GetAllVoucher());

        }
        [HttpGet]
        [Route("api/Voucher/{id}")]
        public async Task<ActionResult<GetVoucherDTO>> GetSingleVoucher(int id)
        {
            var result = await _eventService.GetSingleVoucher(id);
            if (result is null)
            {
                return NotFound("This Voucher is not found!!");
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("api/Voucher")]
        public async Task<ActionResult<List<GetVoucherDTO>>> AddVoucher( AddVoucherDTOcs NewVoucher)
        {
            var result = await _eventService.AddVoucher( NewVoucher);
            return Ok(result);
        }
        [HttpPut]
        [Route("api/Voucher/{id}")]
        public async Task<ActionResult<GetVoucherDTO>> UpdateVoucher(int id, AddVoucherDTOcs UpdateVoucher)
        {
            var result = await _eventService.UpdateVoucher(id, UpdateVoucher);
            if (result is null)
                return NotFound("Voucher not found.");

            return Ok(result);
        }
        [HttpDelete]
        [Route("api/Voucher/{id}")]
        public async Task<ActionResult<List<GetVoucherDTO>>> DeleteVoucher(int id)
        {
            var result = await _eventService.DeleteVoucher(id);
            if (result is null)
                return NotFound("Voucher not found.");

            return Ok(result);
        }

    }
}
