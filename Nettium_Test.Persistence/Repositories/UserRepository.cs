using Nettium_Test.Application.Interfaces.Repositories;
using Nettium_Test.Domain.Entities;
using Nettium_Test.Persistence.Datas;
using Nettium_Test.Persistence.Repositories.Shares;

namespace Nettium_Test.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
