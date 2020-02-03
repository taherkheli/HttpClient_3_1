using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Movies.Client.Services;
using System;

namespace Movies.Client
{
  class Program
  {
    public static void Main()
    {     
      var serviceCollection = new ServiceCollection();
      ConfigureServices(serviceCollection);

      // create a new ServiceProvider
      var serviceProvider = serviceCollection.BuildServiceProvider();

      // For demo purposes: overall catch-all to log any exception that might 
      // happen to the console & wait for key input afterwards so we can easily 
      // inspect the issue.  
      try
      {
        // Run our IntegrationService containing all samples and
        // await this call to ensure the application doesn't 
        // prematurely exit.
        serviceProvider.GetService<IIntegrationService>().Run().GetAwaiter();
      }
      catch (Exception generalException)
      {
        // log the exception
        var logger = serviceProvider.GetService<ILogger<Program>>();
        logger.LogError(generalException, "An exception happened while running the integration service.");
      }

      Console.ReadKey();
    }

    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
      //add loggers
      serviceCollection.AddSingleton(LoggerFactory.Create(builder =>
      {
        builder
          .AddConsole()
          .AddDebug();
      }));

      serviceCollection.AddLogging();

      //register the integration service on our container with a scoped lifetime
      serviceCollection.AddScoped<IIntegrationService, CRUDService>();
    }
  }
}