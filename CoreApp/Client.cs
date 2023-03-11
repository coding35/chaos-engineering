using Polly;
using Polly.Retry;

namespace CoreApp;

public class Client
{
    private readonly HttpClient _httpClient;
    private readonly Polly.Retry.AsyncRetryPolicy _retryPolicy;
    public Client(HttpClient httpClient, AsyncRetryPolicy retryPolicy)
    {
        _httpClient = httpClient;
        _retryPolicy = retryPolicy;
    }
    
    public async Task<string> GetAsync(string url)
    {
        var chaosMonkey = new ChaosMonkey();
        var response = await _retryPolicy.ExecuteAsync(async () =>
        {
            await chaosMonkey.CauseChaos();
            return await _httpClient.GetAsync(url);
        });
        return await response.Content.ReadAsStringAsync();
    }
}