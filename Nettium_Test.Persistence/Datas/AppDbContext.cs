using Microsoft.EntityFrameworkCore;
using Nettium_Test.Domain.Entities;

namespace Nettium_Test.Persistence.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
