namespace DATA.DTO
{
    public class PasswordHistoricDto
    {
        public int IdHistoric { get; set; }

        public string? Password { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int IdAuthentification { get; set; }

        public AuthentificationDto Authentification { get; set; }
    }
}
