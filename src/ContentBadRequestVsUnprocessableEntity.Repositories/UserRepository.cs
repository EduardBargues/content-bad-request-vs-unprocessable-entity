
using System.Threading.Tasks;

using ContentBadRequestVsUnprocessableEntity.Repositories.Abstractions;

namespace ContentBadRequestVsUnprocessableEntity.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> IsUserActive(string userId) => Task.FromResult(false);
    }
}
