using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.DTOs.EventDto
{
    public class GetEventGameDTOcs
    {        
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ClientId { get; set; }        
        public List<GetGameDTO> Games { get; set;} = new List<GetGameDTO>();
    }
}
