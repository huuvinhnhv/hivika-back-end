

namespace Web_Api_Event_Game.Services.EventServices
{
    public interface IClientService
    {      

        //Client
        Task<ServiceResponse<List<GetClientDTO>>> GetAllClient();
        Task<ServiceResponse<GetClientDTO>> GetSingleClient(int id);
        Task<ServiceResponse<List<GetClientDTO>>> AddClient(AddClientDTO NewClient);
        Task<ServiceResponse<GetClientDTO>> UpdateClient(int id, AddClientDTO UpdateClient);
        Task<ServiceResponse<List<GetClientDTO>>> DeleteClient(int id);
       
    }
}
