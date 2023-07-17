using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Coupon>? Coupons { get; set; }
        [JsonIgnore]
        public ICollection<EventGame>? EventGames { get; set; }

    }
}
