using Microsoft.Extensions.DependencyInjection;

namespace HastyBLCAdmin
{
    public partial class Startup
    {
        private void ConfigureMVC(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}
