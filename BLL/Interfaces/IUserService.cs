using DATA.DAL.Entities;
using DATA.DTO;

namespace BLL.Services
{
    public interface IUserService
    {
        UserDto GetUserById(int userId);
        List<UserDto> GetAllUsers();
        UserDto CreateUser(UserDto userDto);
        UserDto CreateBotanist(UserDto userDto);
        UserDto UpdateUser(UserDto userDto);
        void DeleteUser(int userId);
    }
}
