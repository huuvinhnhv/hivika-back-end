

namespace Web_Api_Event_Game.Services.EventServices
{
    public interface IVoucherService
    {
       

        //Voucher
        Task<ServiceResponse<List<GetVoucherDTO>>> GetAllVoucher();
        Task<ServiceResponse<GetVoucherDTO>> GetSingleVoucher(int id);
        Task<ServiceResponse<List<GetVoucherDTO>>> AddVoucher(AddVoucherDTOcs NewEvent);
        Task<ServiceResponse<GetVoucherDTO>> UpdateVoucher(int id, AddVoucherDTOcs UpdateEvent);
        Task<ServiceResponse<List<GetVoucherDTO>>> DeleteVoucher(int id);

       

       
    }
}
