using Neon.CRM.WebApp.Services.Request;
using Neon.CRM.WebApp.Services.Response;
using Branch = Neon.CRM.WebApp.Services.Request.Branch;
using Endpoint = Neon.CRM.WebApp.Services.Request.Endpoint;

namespace Neon.CRM.WebApp.Services;

public class NeonService : INeonService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public NeonService(HttpClient httpClient, IConfiguration config)
    {
        this._httpClient = httpClient;
        this._config = config;

        _httpClient.BaseAddress = new Uri(_config["NeonApi:BaseUrl"]);
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _config["NeonApi:ApiKey"]);
    }

    public async Task<BranchCreateResponse> CreateBranchAsync(string tenantName)
    {
        var projectId = _config["NeonApi:ProjectId"];
        var requestBody = new BranchCreateRequest
        {
            branch = new Branch
            {
                parent_id = _config["NeonApi:ParentBranchId"],
                name = $"tenant_{tenantName.ToLower()}",
                init_source = "schema-only"
            },
            endpoints = new[]
            {
                new Endpoint
                {
                    type = "read_write",
                }
            }
        };

        var response = await _httpClient.PostAsJsonAsync($"projects/{projectId}/branches", requestBody);
        if (response.IsSuccessStatusCode)
        {
            var branchResponse = await response.Content.ReadFromJsonAsync<BranchCreateResponse>();
            return branchResponse;
        }
        else
        {
            throw new Exception($"Failed to create branch: {await response.Content.ReadAsStringAsync()}");
        }
    }
}


