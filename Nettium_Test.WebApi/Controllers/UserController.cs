using Microsoft.AspNetCore.Mvc;
using Nettium_Test.Application.DTOs.Users;
using Nettium_Test.Application.Interfaces.Services;

namespace Nettium_Test.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService,
            ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching user with id {userid}", id);
            var result = await _userService.GetUserByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserAsync()
        {
            _logger.LogInformation("Fetching all user");
            var results = await _userService.GetAllUserAsync();
            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserCreateDto dto)
        {
            _logger.LogInformation("Creating user: {@UserCreateDto}", dto);
            var result = await _userService.CreateUserAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, UserUpdateDto dto)
        {
            _logger.LogInformation("Updating user with id {userid}: {@UserUpdateDto}", id, dto);
            var result = await _userService.UpdateUserAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id)
        {
            _logger.LogInformation("Deleting user with id {userid}", id);
            var result = await _userService.DeleteUserAsync(id);
            return Ok(result);
        }
    }
}
