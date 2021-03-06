using System;
using System.Threading.Tasks;

using ContentBadRequestVsUnprocessableEntity.Repositories.Abstractions;

namespace ContentBadRequestVsUnprocessableEntity.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Task<bool> IsAccountOpen(string accountId) => Task.FromResult(false);
    }
}
