using Data;
using Data.Interfaces;
using Data.Repositories;
using Services.Interfaces;
using Services.ServiceModels;
using Services.Services;
using HastyBLCAdmin.Authentication;
using HastyBLCAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HastyBLCAdmin
{
    // Other services configuration
    internal partial class StartupConfigurer
    {
        /// <summary>
        /// Configures the other services.
        /// </summary>
        private void ConfigureOtherServices()
        {
            // Framework
            this._services!.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            this._services!.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            // Common
            this._services!.AddScoped<TokenProvider>();
            this._services!.TryAddSingleton<TokenProviderOptionsFactory>();
            this._services!.TryAddSingleton<TokenValidationParametersFactory>();
            this._services!.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            this._services!.TryAddSingleton<TokenValidationParametersFactory>();
            this._services!.AddScoped<IUserService, UserService>();
            this._services!.AddScoped<IBookService, BookService>();
            this._services!.AddScoped<IGenreService, GenreService>();

            // Repositories
            this._services!.AddScoped<IUserRepository, UserRepository>();
            this._services!.AddScoped<IBookRepository, BookRepository>();
            this._services!.AddScoped<IGenreRepository, GenreRepository>();

            // Manager Class
            this._services!.AddScoped<SignInManager>();

            this._services!.AddHttpClient();
        }
    }
}
