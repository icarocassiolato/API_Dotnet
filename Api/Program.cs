using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DotNetEnv.Env.Load();
            var config = new ConfigurationBuilder()
                        .AddEnvironmentVariables()
                        .Build();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) => { builder.SetBasePath(context.HostingEnvironment.ContentRootPath); })
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
                .UseStartup<Startup>();
    }
}
