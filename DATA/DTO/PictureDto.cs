namespace DATA.DTO
{
    public class PictureDto
    {
        public int IdPicture { get; set; }

        public string? Path { get; set; }

        public DateTime? UpdateDate { get; set; }

        public List<MaintenanceDto> MaintenanceCollection { get; set; }

        public List<PlantDto> PlantCollection { get; set; }
    }
}
