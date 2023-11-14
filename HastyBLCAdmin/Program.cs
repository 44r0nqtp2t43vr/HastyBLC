/*using System.IO;
using Data;
using HastyBLCAdmin;
using HastyBLCAdmin.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var appBuilder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ContentRootPath = Directory.GetCurrentDirectory(),
});

appBuilder.Configuration.AddJsonFile("appsettings.json",
    optional: true,
    reloadOnChange: true);

appBuilder.WebHost.UseIISIntegration();

appBuilder.Logging
    .AddConfiguration(appBuilder.Configuration.GetLoggingSection())
    .AddConsole()
    .AddDebug();

var configurer = new StartupConfigurer(appBuilder.Configuration);
configurer.ConfigureServices(appBuilder.Services);

var app = appBuilder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    Seed.SeedData(app);
}

configurer.ConfigureApp(app, app.Environment);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}");
app.MapControllers();
app.MapRazorPages();

// Run application
app.Run();*/

using Data;
using Data.Interfaces;
using Data.Repositories;
using HastyBLCAdmin.Authentication;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using Services.Services;
using System.IO;

namespace HastyBLCAdmin
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            if (args.Length == 1 && args[0].ToLower() == "seeddata")
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Services.AddDbContext<HastyDBContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
                builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<HastyDBContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();
                var app = builder.Build();
                Seed.SeedData(app);
            }      
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .ConfigureAppConfiguration(SetUpConfiguration)
                .UseStartup<Startup>();

        private static void SetUpConfiguration(WebHostBuilderContext builderCtx, IConfigurationBuilder config)
        {
            config.Sources.Clear();     // Clears the default configuration options

            IWebHostEnvironment env = builderCtx.HostingEnvironment;

            // Include settings file back to the configuration
            config.SetBasePath(env.ContentRootPath)
                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                   .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                   .AddEnvironmentVariables();
        }
    }
}