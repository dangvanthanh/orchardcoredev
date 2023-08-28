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
                .DefineStyle("codyschool-husky-css")
                .SetUrl("~/CodySchool.Husky/css/codyschool-husky.min.css", "~/CodySchool.Husky/css/codyschool-husky.css")
                .SetVersion("1.0.0");
        }

        public void Configure(ResourceManagementOptions options)
        {
            options.ResourceManifests.Add(_manifest);
        }
    }
}