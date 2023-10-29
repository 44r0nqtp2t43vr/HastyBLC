using Data.Models;
using Services.ServiceModels;
using AutoMapper;
using Data.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HastyBLCAdmin
{
    public partial class Startup
    {
        private void ConfigureMapper(IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperProfileConfiguration());
            });

            services.AddSingleton<IMapper>(sp => mapperConfiguration.CreateMapper());
            /*var Config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JobOpening, JobOpeningViewModel>();
            });

            services.AddSingleton(Config.CreateMapper());*/
        }

        private class AutoMapperProfileConfiguration : Profile
        {
            public AutoMapperProfileConfiguration()
            {
                CreateMap<UserViewModel, User>();
            }
        }
    }
}