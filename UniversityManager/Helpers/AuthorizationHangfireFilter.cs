using Hangfire.Annotations;
using Hangfire.Dashboard;
using System.Web;

namespace UniversityManager.Helpers
{
    public class AuthorizationHangfireFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            return HttpContext.Current.User.IsInRole("Admin");
        }
    }
}