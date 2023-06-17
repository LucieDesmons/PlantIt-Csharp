namespace DATA.DTO
{
    public class ManageDto
    {
        public int IdUserCustomer { get; set; }

        public int IdUserBotanist { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public UserDto Botanist{ get; set; }

        public UserDto Customer { get; set; }
    }
}
