namespace DATA.DTO
{
    public class UserDto
    {
        public int IdUser { get; set; }

        public string? Name { get; set; }

        public string? FirstName { get; set; }

        public string? Phone { get; set; }

        public string? Degree { get; set; }

        public string? Specialization { get; set; }

        public string? Hobbies { get; set; }

        public int IdAddress { get; set; }

        public int IdUserType { get; set; }

        public int IdAuthentication { get; set; }

        public AddressDto Address { get; set; }

        public AuthenticationDto Authentication { get; set; }

        public UserTypeDto UserType { get; set; }

        public List<BankDetailDto> BankDetailsCollection { get; set; }

        public List<ConversationDto> ConversationUser1Collection { get; set; }

        public List<ConversationDto> ConversationUser2Collection { get; set; }

        public List<CreatedByDto> CreatedByCollection { get; set; }

        public List<MaintenanceDto> MaintenanceCollection { get; set; }

        public List<ManageDto> ManageBotanistCollection { get; set; }

        public List<ManageDto> ManageCustomerCollection { get; set; }

        public List<PlantDto> PlantCollection { get; set; }

        public List<UserHistoricDto> UserHistoricCollection { get; set; }
    }
}
