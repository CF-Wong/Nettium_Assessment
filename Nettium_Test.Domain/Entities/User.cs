namespace Nettium_Test.Domain.Entities
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
            IsActive = true;
        }

        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string EmailAddress { get; set; }
        public required string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
