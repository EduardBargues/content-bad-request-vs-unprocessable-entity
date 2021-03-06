using System;
using System.Threading.Tasks;

using ContentBadRequestVsUnprocessableEntity.Repositories.Abstractions;
using ContentBadRequestVsUnprocessableEntity.Services.Abstractions;

namespace ContentBadRequestVsUnprocessableEntity.Services
{
    public class ProcessService : IProcessService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        public ProcessService(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public async Task<string> InitiateProcessAsync(string userId, string accountId)
        {
            if (!await _userRepository.IsUserActive(userId))
            {
                BussinessException.UserIsInactive().Launch();
            }
            if (!await _accountRepository.IsAccountOpen(accountId))
            {
                BussinessException.AccountIsClosed().Launch();
            }

            // INITIATE PROCESS HERE :) !!
            return "process-id";
        }
    }
}
