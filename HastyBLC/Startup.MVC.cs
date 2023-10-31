using Microsoft.Extensions.DependencyInjection;

namespace HastyBLC
{
    public partial class Startup
    {
        private void ConfigureMVC(IServiceCollection services)
        {
            services.AddMvc();
        }
    }
}
