using AscentCsvBuilder.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace AscentCsvBuilder;

public class AscentDataService
{
    private readonly HttpClient _httpClient;

    private string _companyName;
    private string _profileId;

    public AscentDataService(string companyName, string profileId, string apiToken)
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
        _companyName = companyName;
        _profileId = profileId;
    }

    public async Task<AscentResponse> GetRegulators()
    {
        var httpResponse = await _httpClient.GetFromJsonAsync<AscentResponse>($"https://{_companyName}.ascentregtech.com/api/v0/profiles/{_profileId}/regulators");
        return httpResponse ?? new AscentResponse();
    }
    public async Task<AscentResponse> GetRules(string regulatorId)
    {
        var httpResponse = await _httpClient.GetFromJsonAsync<AscentResponse>($"https://{_companyName}.ascentregtech.com/api/v0/profiles/{_profileId}/regulators/{regulatorId}/rules");
        return httpResponse ?? new AscentResponse();
    }
    public async Task<AscentResponse> GetTasks()
    {
        var httpResponse = await _httpClient.GetFromJsonAsync<AscentResponse>($"https://{_companyName}.ascentregtech.com/api/v0/profiles/{_profileId}/tasks");
        return httpResponse ?? new AscentResponse();
    }
    public async Task<AscentResponse> GetSupportingTasks(string taskId)
    {
        var httpResponse = await _httpClient.GetFromJsonAsync<AscentResponse>($"https://{_companyName}.ascentregtech.com/api/v0/profiles/{_profileId}/tasks/{taskId}/supporting_informations");
        return httpResponse ?? new AscentResponse();
    }
    public async Task<AscentResponse> GetByUrl(string url)
    {
        var httpResponse = await _httpClient.GetFromJsonAsync<AscentResponse>(url);
        return httpResponse ?? new AscentResponse();
    }
}

