namespace Nettium_Test.Application.DTOs.Users
{
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
