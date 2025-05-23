using Nettium_Test.Application.DTOs.Users;

namespace Nettium_Test.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllUserAsync();
        Task<UserDto> CreateUserAsync(UserCreateDto dto);
        Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto dto);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
