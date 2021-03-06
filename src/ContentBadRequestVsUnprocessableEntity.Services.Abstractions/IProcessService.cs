using System.Threading.Tasks;

namespace ContentBadRequestVsUnprocessableEntity.Services.Abstractions
{
    public interface IProcessService
    {
        Task<string> InitiateProcessAsync(string userId, string accountId);
    }
}
