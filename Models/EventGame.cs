using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.Models
{
    public class EventGame
    {
        public int EventId { get; set; }
        public int GameId { get; set; }
        [JsonIgnore]
        public Event? Event { get; set; }
        [JsonIgnore]
        public Game? Game { get; set; }
        
    }

}
