namespace DATA.DTO
{
    public class PlantReferenceDto
    {
        public int IdPlantReference { get; set; }

        public string? Name { get; set; }

        public string? Family { get; set; }

        public string? Size { get; set; }

        public string? FoodSource { get; set; }

        public string? Reproduction { get; set; }

        public string? Lifetime { get; set; }

        public string? PlaceLife { get; set; }

        public string? Description { get; set; }

        public List<CreatedByDto> CreatedByCollection { get; set; }

        public List<PictureReferenceDto> PictureReferenceCollection { get; set; }

        public List<PlantDto> PlantCollection { get; set; }

    }
}
