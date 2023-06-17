namespace DATA.DTO
{
    public class CreatedByDto
    {
        public int IdPlantReference { get; set; }

        public int IdUser { get; set; }

        public int? OrderNum { get; set; }

        public DateTime? UpdateDate { get; set; }

        public PlantReferenceDto PlantReference { get; set; }

        public UserDto User { get; set; }
    }
}
