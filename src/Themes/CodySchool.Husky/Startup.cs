using CodySchool.Husky.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Modules;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.ResourceManagement;

namespace CodySchool.Husky
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManagementOptionsConfiguration>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            var homeControllerName = typeof(HomeController).ControllerName();

            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "CodySchool.Husky",
                pattern: "{Action}",
                defaults: new { controller = homeControllerName, action = nameof(HomeController.Index) }
            );
        }
    }
}