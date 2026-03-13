namespace FarmerApp.Api.DTOs
{
    public class CropCatalogDto
    {
        public string Note { get; set; } = string.Empty;

        public List<CropSeedDto> SeedTypes { get; set; } = new();

        public List<string> SoilTypes { get; set; } = new();
    }

    public class CropSeedDto
    {
        public string Name { get; set; } = string.Empty;

        public string Tuber { get; set; } = string.Empty;

        public string Storability { get; set; } = string.Empty;

        public string ConsumerAndProcessingQuality { get; set; } = string.Empty;

        public string Maturity { get; set; } = string.Empty;

        public string Yield { get; set; } = string.Empty;

        public string SpecialFeatures { get; set; } = string.Empty;
    }
}
