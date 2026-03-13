using FarmerApp.Api.Data;
using FarmerApp.Api.DTOs;
using FarmerApp.Api.Models;
using MongoDB.Driver;

namespace FarmerApp.Api.Services
{
    public class CropService
    {
        private readonly AppDbContext _db;

        private static readonly List<CropSeedDto> SeedCatalog =
        [
            new CropSeedDto
            {
                Name = "Kufri Chipsona-3",
                Tuber = "White cream tubers with good processing quality",
                Storability = "Good",
                ConsumerAndProcessingQuality = "Suitable for chips and processing use",
                Maturity = "Medium (90-110 Days)",
                Yield = "30-35 tonnes/hectare",
                SpecialFeatures = "Good dry matter and processing suitability"
            },
            new CropSeedDto
            {
                Name = "Kufri Himalini",
                Tuber = "White cream, oval tubers",
                Storability = "Good",
                ConsumerAndProcessingQuality = "Suitable for table purpose",
                Maturity = "Medium (90-110 Days)",
                Yield = "30-32 tonnes/hectare",
                SpecialFeatures = "Adapted to hill conditions"
            },
            new CropSeedDto
            {
                Name = "Kufri Jyoti",
                Tuber = "White-cream, ovoid tubers with shallow eyes and cream flesh",
                Storability = "Very good",
                ConsumerAndProcessingQuality = "Easy to cook, texture waxy, flavor very good, free from after-cooking discoloration; Suitable for table purpose; Good for processing when grown in warmer areas",
                Maturity = "Medium (90-100 Days)",
                Yield = "35-30 tonnes/hectare",
                SpecialFeatures = "Early bulker with slow rate of degeneration and wider adaptability"
            },
            new CropSeedDto
            {
                Name = "Kufri Uday",
                Tuber = "Attractive white cream tubers",
                Storability = "Good",
                ConsumerAndProcessingQuality = "Suitable for table purpose",
                Maturity = "Medium (90-100 Days)",
                Yield = "35-40 tonnes/hectare",
                SpecialFeatures = "Early harvest potential"
            },
            new CropSeedDto
            {
                Name = "Kufri Megha",
                Tuber = "White cream, ovoid, medium-deep eye",
                Storability = "Good",
                ConsumerAndProcessingQuality = "Easy to cook, texture floury, flavour mild, free from after-cooking discoloration, Suitable for table purpose",
                Maturity = "Medium (90-100 Days)",
                Yield = "22-28 t/hectare",
                SpecialFeatures = "Resistant to Late blight"
            },
            new CropSeedDto
            {
                Name = "Kufri Karan",
                Tuber = "Large white cream tubers",
                Storability = "Good",
                ConsumerAndProcessingQuality = "Suitable for table purpose and fast cooking",
                Maturity = "Medium (100-110 Days)",
                Yield = "30-35 tonnes/hectare",
                SpecialFeatures = "Stable yield and wide adaptability"
            }
        ];

        private static readonly List<string> SoilCatalog =
        [
            "Sandy Soil",
            "Clay Soil",
            "Silt Soil",
            "Peat Soil",
            "Chalk Soil",
            "Loamy Soil"
        ];

        public CropService(AppDbContext db)
        {
            _db = db;
        }

        public CropCatalogDto GetCatalog()
        {
            return new CropCatalogDto
            {
                Note = "Expected potential yield per hectare is only when appropriate SOPs followed, Optimal soil and climatic conditions.",
                SeedTypes = SeedCatalog,
                SoilTypes = SoilCatalog
            };
        }

        public async Task<CropEntry?> CreateCropAsync(string userId, string userPhone, AddCropDto dto)
        {
            var crop = new CropEntry
            {
                UserId = userId,
                UserPhone = userPhone,
                StartDate = dto.StartDate,
                AreaOfPlanting = dto.AreaOfPlanting,
                SeedRate = dto.SeedRate,
                SeedType = dto.SeedType.Trim(),
                SoilType = dto.SoilType.Trim(),
                Latitude = dto.Latitude,
                Longitude = dto.Longitude
            };

            await _db.CropEntries.InsertOneAsync(crop);
            return crop;
        }

        public async Task<List<CropEntry>> GetCropsByUserAsync(string userId)
        {
            return await _db.CropEntries
                .Find(crop => crop.UserId == userId)
                .SortByDescending(crop => crop.CreatedAt)
                .ToListAsync();
        }
    }
}
