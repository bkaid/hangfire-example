using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HangPoc.Web.Startup))]

namespace HangPoc.Web {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("TasksContext");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(() => Jobs.ExpireTasks.Execute(), "*/1 * * * *");
        }
    }
}