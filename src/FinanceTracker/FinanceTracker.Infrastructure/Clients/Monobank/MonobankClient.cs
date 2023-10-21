using System.Net.Http.Json;
using FinanceTracker.Infrastructure.Clients.Monobank.Responses;

namespace FinanceTracker.Infrastructure.Clients.Monobank;

public sealed class MonobankClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://api.monobank.ua/bank";
    
    public MonobankClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<MonobankCurrencyRateResponse>> GetRateAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<MonobankCurrencyRateResponse>>($"{_baseUrl}/currency");
    }
}
