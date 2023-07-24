using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Descriptors;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Modules;
using CodySchool.Core.Models;

namespace CodySchool.Core
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            // services.AddScoped<IDisplayDriver<Book>, BookDisplayDriver>();
            // services.AddScoped<IDisplayManager<Book>, DisplayManager<Book>>();
            // services.AddDataMigration<BookMigrations>();
            // services.AddIndexProvider<BookIndexProvider>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Home",
                areaName: "CodySchool.Core",
                pattern: "Home/{Action}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
