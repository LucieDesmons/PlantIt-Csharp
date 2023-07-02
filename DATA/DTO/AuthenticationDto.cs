using System.ComponentModel.DataAnnotations;

namespace DATA.DTO
{
    public class AuthenticationDto
    {
        public int IdAuthentication { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<PasswordHistoricDto> PasswordHistoricCollection { get; set; }
    }
}
