using System.Threading.Tasks;

namespace ContentBadRequestVsUnprocessableEntity.Repositories.Abstractions
{
    public interface IAccountRepository
    {
        Task<bool> IsAccountOpen(string accountId);
    }
}
