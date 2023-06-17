namespace DATA.DTO
{
    public class UserTypeDto
    {
        public int IdUserType { get; set; }

        public string? Label { get; set; }

        public List<UserDto> UserCollection { get; set; } = new List<UserDto>();
    }
}
