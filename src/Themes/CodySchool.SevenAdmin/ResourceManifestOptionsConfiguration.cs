using Microsoft.Extensions.Options;
using OrchardCore.ResourceManagement;

namespace CodySchool.SevenAdmin
{
    public class ResourceManifestOptionsConfiguration : IConfigureOptions<ResourceManagementOptions>
    {
        private static ResourceManifest _manifest;

        static ResourceManifestOptionsConfiguration()
        {
            _manifest = new ResourceManifest();

            _manifest
                .DefineStyle("codyschool-admin")
                .SetUrl("~/CodySchool.SevenAdmin/css/codyschool-admin.min.css", "~/CodySchool.SevenAdmin/css/codyschool-admin.css")
                .SetVersion("1.0.0");

            _manifest
                .DefineStyle("codyschool-admin-plugins")
                .SetUrl("~/CodySchool.SevenAdmin/css/codyschool-admin-plugins.min.css", "~/CodySchool.SevenAdmin/css/codyschool-admin-plugins.css")
                .SetVersion("1.0.0");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}