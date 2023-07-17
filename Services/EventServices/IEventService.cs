

namespace Web_Api_Event_Game.Services.EventServices
{
    public interface IEventService
    {
        //Event
        Task<ServiceResponse<List<GetEventDTO>>> GetAllEvents();
        Task<ServiceResponse<GetEventGameDTOcs>> GetSingleEvent(int id);
        Task<ServiceResponse<List<GetEventDTO>>> AddEvent( AddEventDTO NewEvent);
        Task<ServiceResponse<GetEventDTO>> UpdateEvent(int id, AddEventDTO UpdateEvent);
        Task<ServiceResponse<List<GetEventDTO>>> DeleteEvent(int id);

        //Add game to Event
        Task<ServiceResponse<GetEventGameDTOcs>> AddGameToEvent(AddGameToEventDTO GameEvent);
        //get all table eventGame
        Task<ServiceResponse<List<EventGame>>> GetAllGameEvent();
    }
}
