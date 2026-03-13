using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FarmerApp.Api.Models
{
    public class CropEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public required string UserId { get; set; }

        public required string UserPhone { get; set; }

        public DateTime StartDate { get; set; }

        public decimal AreaOfPlanting { get; set; }

        public decimal SeedRate { get; set; }

        public required string SeedType { get; set; }

        public required string SoilType { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
