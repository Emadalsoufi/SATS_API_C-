using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDto userDto);
        void UpdateUser(UserDto userDto);
        UserDto? GetUserById(int id);
        IEnumerable<UserDto> GetAllUsers();
    }

}
