using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;
namespace CodySchool.Core.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotifier _notifier;
        private readonly IStringLocalizer T;
        private readonly IHtmlLocalizer H;
        private readonly ILogger _logger;

        public HomeController(INotifier notifier,
            IStringLocalizer<HomeController> stringLocalizer,
            IHtmlLocalizer<HomeController> htmlLocalizer,
            ILogger<HomeController> logger)
        {
            _notifier = notifier;
            _logger = logger;

            T = stringLocalizer;
            H = htmlLocalizer;
        }

        public ActionResult Index()
        {
            ViewData["Message"] = T["CodySchool Core!"];
            return View();
        }

        [Route("Home/Notify")]
        public async Task<IActionResult> Notify()
        {
            _logger.LogError("You have been notified about some error!");

            await _notifier.InformationAsync(H["Congratulations! You have been notified! Check the error log too!"]);

            return View();
        }
    }
}
