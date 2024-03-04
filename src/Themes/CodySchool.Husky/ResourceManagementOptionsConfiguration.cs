using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace CodySchool.Husky
{
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static readonly ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineScript("codyschool-husky-js")
                .SetUrl("~/CodySchool.Husky/js/codyschool-husky.js", "~/CodySchool.Husky/js/codyschool-husky.js")
                .SetVersion("1.0.0");

           _manifest
                .DefineStyle("codyschool-husky-css")
                .SetUrl("~/CodySchool.Husky/css/codyschool-husky.css", "~/CodySchool.Husky/css/codyschool-husky.css")
                .SetVersion("1.0.0");

            _manifest
                .DefineScript("codyschool-dashboard-js")
                .SetUrl("~/CodySchool.Husky/js/codyschool-dashboard.js", "~/CodySchool.Husky/js/codyschool-dashboard.js")
                .SetVersion("1.0.0");

           _manifest
                .DefineStyle("codyschool-dashboard-css")
                .SetUrl("~/CodySchool.Husky/css/codyschool-dashboard.css", "~/CodySchool.Husky/css/codyschool-dashboard.css")
                .SetVersion("1.0.0");    
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}