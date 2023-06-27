using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;
using System.Threading.Tasks;

namespace CodySchool.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotifier _notifier;
        private readonly IStringLocalizer T;
        private readonly IHtmlLocalizer H;

        private readonly ILogger _logger;

        public ActionResult Index()
        {
            return View();
        }
    }
}
