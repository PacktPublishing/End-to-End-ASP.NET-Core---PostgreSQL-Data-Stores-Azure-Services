using Neon.CRM.WebApp.Services.Response;

namespace Neon.CRM.WebApp.Services
{
    public interface INeonService
    {
        Task<BranchCreateResponse> CreateBranchAsync(string tenantName);
    }
}