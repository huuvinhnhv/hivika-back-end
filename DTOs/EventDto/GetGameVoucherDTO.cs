using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.DTOs.EventDto
{
    public class GetGameVoucherDTO
    {
        public int GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<GetVoucherDTO> Coupons { get; set; } = new List<GetVoucherDTO>();
        
    }
}
