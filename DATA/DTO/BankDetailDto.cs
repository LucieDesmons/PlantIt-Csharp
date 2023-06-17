namespace DATA.DTO
{
    public class BankDetailDto
    {
        public int IdBankDetails { get; set; }

        public string? Details { get; set; }

        public int IdUser { get; set; }

        public UserDto User { get; set; }
    }
}
