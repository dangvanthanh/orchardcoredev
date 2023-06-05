using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace CodySchool.Theme
{
    public class ResourceManagementOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManagementOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineStyle("codyschool-theme")
                .SetUrl("~/CodySchool.Theme/css/codyschool-theme.min.css", "~/CodySchool.Theme/css/codyschool-theme.css")
                .SetVersion("1.0.0");

            _manifest
                .DefineScript("codyschool-theme")
                .SetUrl("~/CodySchool.Theme/js/codyschool-theme.min.js", "~/CodySchool.Theme/js/codyschool-theme.js")
                .SetVersion("1.0.0");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}