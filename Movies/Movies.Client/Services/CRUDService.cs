using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Client.Services
{
  public class CRUDService : IIntegrationService
  {
    private static readonly HttpClient _httpClient = new HttpClient();

    public CRUDService()
    {
      _httpClient.BaseAddress = new Uri("http://localhost:57863");
      _httpClient.Timeout = new TimeSpan(0, 0, 30);
    }

    public async Task Run()
    {
      await GetResource();
    }

    public async Task GetResource()
    {
      var response = await _httpClient.GetAsync("api/movies");      
      response.EnsureSuccessStatusCode();
    }
  }
}
