using Hangfire;
using Microsoft.Owin;
using Owin;
using UniversityManager.Helper;
using UniversityManager.Helpers;

[assembly: OwinStartupAttribute(typeof(UniversityManager.Startup))]
namespace UniversityManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //SeederDatabase.SeedData();

            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard("/HangfireDashboard", new DashboardOptions
            {
                Authorization = new[] { new AuthorizationHangfireFilter() }
            });


    

            app.UseHangfireServer();

        }
    }
}
