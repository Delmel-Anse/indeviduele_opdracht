using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class RestService
{
    private readonly HttpClient _client;
    private const string rest_url = "https://m4ks7lhf-7162.euw.devtunnels.ms/api/NDS";
    public RestService()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri(rest_url);
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // Method to perform GET request
    public async Task<string> GetAsync(string endpoint)
    {
        HttpResponseMessage response = await _client.GetAsync(endpoint);
        response.EnsureSuccessStatusCode(); // Throw if not success
        return await response.Content.ReadAsStringAsync();
    }


  
}
