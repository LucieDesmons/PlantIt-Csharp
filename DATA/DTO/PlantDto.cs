namespace DATA.DTO
{
    public class PlantDto
    {
        public int IdPlant { get; set; }

        public string? Name { get; set; }

        public string? PlacePlant { get; set; }

        public string? Container { get; set; }

        public int? Humidity { get; set; }

        public int? Clarity { get; set; }

        public int IdUser { get; set; }

        public int IdPlantReference { get; set; }

        public PlantReferenceDto PlantReference { get; set; }

        public UserDto User { get; set; }

        public List<ConversationDto> ConversationCollection { get; set; }

        public List<PictureDto> PictureCollection { get; set; }
    }
}
