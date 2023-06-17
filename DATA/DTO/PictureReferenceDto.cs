namespace DATA.DTO
{
    public class PictureReferenceDto
    {
        public int IdPictureReference { get; set; }

        public string? Path { get; set; }

        public DateTime? ModificationDate { get; set; }

        public List<PlantReferenceDto> PlantReferenceCollection { get; set; }
    }
}
