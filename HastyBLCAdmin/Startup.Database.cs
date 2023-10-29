using Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HastyBLCAdmin
{
    public partial class Startup
    {
        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<HastyDBContext>(
            options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."),
                    optionsAction => { }
                )
            );

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<HastyDBContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();      
        }
    }
}