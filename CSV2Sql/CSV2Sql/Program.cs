using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
class Program
{
    private static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddEnvironmentVariables();
            })
            .ConfigureServices((context, services) =>
            {
                var configuration = context.Configuration;
                var connectionString = configuration.GetValue<string>("CSV_2_SQL_CONNECTION_STRING");

                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(connectionString).UseLazyLoadingProxies());

            })
            .Build();
    }
}