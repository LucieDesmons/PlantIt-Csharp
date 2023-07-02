namespace DATA.DTO
{
    public class PasswordHistoricDto
    {
        public int IdHistoric { get; set; }

        public string? Password { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int IdAuthentication { get; set; }

        public AuthenticationDto Authentication { get; set; }
    }
}
