using AutoMapper;

namespace Web_Api_Event_Game
{
    public class GameEvent_Voucher:Profile
    {
        public GameEvent_Voucher()
        {
            CreateMap<Event,GetEventDTO>();
            CreateMap<AddEventDTO, Event>();

            CreateMap<Game, GetGameDTO>();
            CreateMap<AddGameDTO, Game>();

            CreateMap<Coupon, GetVoucherDTO>();
            CreateMap<AddVoucherDTOcs, Coupon>();

            CreateMap<Client, GetClientDTO>();
            CreateMap<AddClientDTO, Client>();

            CreateMap<EventGame, GetEventGameDTOcs>();
            CreateMap<AddGameToEventDTO, EventGame>();
        }
    }
}
