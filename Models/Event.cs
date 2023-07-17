using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public Client? Client { get; set; }
        public int? ClientId { get; set; }
        [JsonIgnore]
        public ICollection<EventGame>? EventGames { get; set; }

    }
}
