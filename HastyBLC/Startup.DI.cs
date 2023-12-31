﻿using Data;
using Data.Interfaces;
using Data.Repositories;
using Services.Interfaces;
using Services.ServiceModels;
using Services.Services;
using HastyBLC.Authentication;
using HastyBLC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace HastyBLC
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


            // Repositories
            this._services!.AddScoped<IUserRepository, UserRepository>();

            // Manager Class
            this._services!.AddScoped<SignInManager>();

            this._services!.AddHttpClient();
        }
    }
}
