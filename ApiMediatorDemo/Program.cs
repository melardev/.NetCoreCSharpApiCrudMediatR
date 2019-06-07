using System.Threading.Tasks;
using ApiMediatorDemo.Data;
using ApiMediatorDemo.Seeds;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMediatorDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var appDbContext = services.GetRequiredService<ApplicationDbContext>();
                await DbSeeder.Seed(appDbContext);
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://localhost:8080", "http://localhost:5001")
                .UseStartup<Startup>();
    }
}