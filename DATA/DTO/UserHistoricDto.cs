using System.ComponentModel.DataAnnotations;

namespace DATA.DTO
{
    public class UserHistoricDto
    {
        public int IdUserHistoric { get; set; }

        public int IdUser { get; set; }

        [Required]
        public string Action { get; set; }

        public string? Reason { get; set; }

        public DateTime Date { get; set; }

        public UserDto User { get; set; }
    }
}
