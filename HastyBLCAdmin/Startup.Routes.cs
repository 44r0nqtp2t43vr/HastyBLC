using Microsoft.AspNetCore.Builder;

namespace HastyBLCAdmin
{
    public partial class Startup
    {
        private void ConfigureRoutes(IApplicationBuilder app)
        {            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");

                endpoints.MapControllerRoute(
                    name: "token",
                    pattern: "api/{token}");

                endpoints.MapControllerRoute(
                    name: "404",
                    pattern: "{controller=Error}/{action=Forbidden}");

                endpoints.MapRazorPages();
            });
        }
    }
}
