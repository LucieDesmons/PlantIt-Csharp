namespace DATA.DTO
{
    public class AddressDto
    {
        public int IdAddress { get; set; }

        public int? Number { get; set; }

        public string? PostalCode { get; set; }

        public string? Way { get; set; }

        public string? AdditionalAddress { get; set; }

        public string? Town { get; set; }

        public UserDto? User { get; set; }
    }
}
