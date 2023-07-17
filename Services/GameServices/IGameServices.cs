namespace Web_Api_Event_Game.Services.GameServices
{
    public interface IGameServices
    {
        //game
        Task<ServiceResponse<List<GetGameDTO>>> GetAllGame();
        Task<ServiceResponse<GetGameVoucherDTO>> GetSingleGame(int id);
        Task<ServiceResponse<List<GetGameDTO>>> AddGame(AddGameDTO NewEvent);
        Task<ServiceResponse<GetGameDTO>> UpdateGame(int id, AddGameDTO UpdateEvent);
        Task<ServiceResponse<List<GetGameDTO>>> DeleteGame(int id);
    }
}
