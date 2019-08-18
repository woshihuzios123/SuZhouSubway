using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SuZhouSubway.Model.Data;
using System;
using System.Threading.Tasks;

namespace SuZhouSubway.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            await InitDataBase(host.Services.CreateScope());
            await host.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        private static async Task InitDataBase(IServiceScope scope)
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<SubwayDbContext>();
                await DbInitializer.Initialize(context); // 
            }
            catch (Exception e)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "初始化数据库发生错误.");
            }
        }
    }
}