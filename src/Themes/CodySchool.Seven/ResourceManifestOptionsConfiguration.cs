using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace CodySchool.Seven
{
    public class ResourceManifestOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManifestOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineStyle("codyschool")
                .SetUrl("~/CodySchool.Seven/css/codyschool.min.css", "~/CodySchool.Seven/css/codyschool.css")
                .SetVersion("1.0.0");

            _manifest
                .DefineStyle("codyschool-plugins")
                .SetUrl("~/CodySchool.Seven/css/codyschool-plugins.min.css", "~/CodySchool.Seven/css/codyschool-plugins.css")
                .SetVersion("1.0.0");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}