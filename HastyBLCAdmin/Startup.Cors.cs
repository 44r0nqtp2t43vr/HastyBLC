using Microsoft.Extensions.DependencyInjection;

namespace HastyBLCAdmin
{
    public partial class Startup
    {
        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }
    }
}
