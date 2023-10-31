﻿using Microsoft.AspNetCore.Builder;

namespace HastyBLC
{
    public partial class Startup
    {
        private void ConfigureRoutes(IApplicationBuilder app)
        {            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Dashboard}/{id?}");

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