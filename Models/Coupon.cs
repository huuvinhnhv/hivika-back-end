using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Web_Api_Event_Game.Models
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Discount { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public int EventId { get; set; } = int.MaxValue;
        [JsonIgnore]
        public Game? Game { get; set; }        
        public int? GameId { get; set; }

    }
}
