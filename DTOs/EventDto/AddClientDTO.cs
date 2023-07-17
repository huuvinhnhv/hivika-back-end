
using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.DTOs.EventDto
{
    public class AddClientDTO
    {        
        public string ClientName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
