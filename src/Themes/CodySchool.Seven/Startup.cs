using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Environment.Shell.Configuration;
using OrchardCore.Modules;
using OrchardCore.ResourceManagement;

namespace CodySchool.Seven
{
    public class Startup : StartupBase
    {
        private readonly IShellConfiguration _configuration;

        public Startup(IShellConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<ResourceManagementOptions>, ResourceManifestOptionsConfiguration>();
        }
    }
}