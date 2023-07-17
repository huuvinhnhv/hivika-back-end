using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.DTOs.EventDto
{
    public class GetVoucherDTO
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Discount { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public int  EventId { get; set; } = int.MaxValue;
    }
}
