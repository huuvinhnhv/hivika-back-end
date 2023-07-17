using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.DTOs.EventDto
{
    public class AddGameDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
}
