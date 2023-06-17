namespace DATA.DTO
{
    public class MaintenanceDto
    {
        public int IdMaintenance { get; set; }

        public DateTime? PredictedDate { get; set; }

        public DateTime? RealizedDate { get; set; }

        public string? Report { get; set; }

        public List<PictureDto> PictureCollection { get; set; }

        public List<UserDto> UserCollection { get; set; }
    }
}
