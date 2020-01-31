using System;
using System.Net.Http;

namespace Movies.Client
{
  class Program
  {
    static void Main()
    {
      var client = new HttpClient
      {
        BaseAddress = new Uri("http://localhost:57863")
      };

      var result = client.GetAsync("/api/movies").GetAwaiter().GetResult();
      Console.WriteLine(result.IsSuccessStatusCode);
      Console.WriteLine("Hello World!");
    }
  }
}
