using System;
using System.Threading.Tasks;

namespace ContentBadRequestVsUnprocessableEntity.Repositories.Abstractions
{
    public interface IUserRepository
    {
        Task<bool> IsUserActive(string userId);
    }
}
