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
                .DefineStyle("codyschool-css")
                .SetUrl("~/CodySchool.Theme/css/codyschool.min.css", "~/CodySchool.Theme/css/codyschool.css")
                .SetVersion("1.0.0");

            _manifest
                .DefineScript("codyschool-js")
                .SetUrl("~/CodySchool.Theme/js/codyschool.min.js", "~/CodySchool.Theme/js/codyschool.js")
                .SetVersion("1.0.0");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}