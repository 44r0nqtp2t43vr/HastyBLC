using System.IO;
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
app.Run();
