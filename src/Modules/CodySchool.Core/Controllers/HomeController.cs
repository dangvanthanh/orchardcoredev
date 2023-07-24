using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.ModelBinding;
using CodySchool.Core.Models;

namespace CodySchool.Core.Controllers
{
    public class HomeController : Controller, IUpdateModel
    {
        private readonly INotifier _notifier;
        private readonly IStringLocalizer T;
        private readonly IHtmlLocalizer H;
        private readonly ILogger _logger;

        private readonly IDisplayManager<Book> _bookDisplayManager;

        public HomeController(INotifier notifier,
            IStringLocalizer<HomeController> stringLocalizer,
            IHtmlLocalizer<HomeController> htmlLocalizer,
            ILogger<HomeController> logger,
            IDisplayManager<Book> bookDisplayManager)
        {
            _notifier = notifier;
            _logger = logger;
            _bookDisplayManager = bookDisplayManager;

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

        public ActionResult AdHocShape() => View();

        public async Task<IActionResult> DisplayBookDescription()
        {
            // Generate another book object to be used for demonstration purposes.
            var book = CreateDemoBook();

            // This time give an additional parameter which is the display type. If display type is given then Orchard Core
            // will search a cshtml file with a name [ClassName].[DisplayType].cshtml.
            var shape = await _bookDisplayManager.BuildDisplayAsync(book, this, "Description");

            // NEXT STATION: Go to Views/Book.Description.cshtml

            return View(shape);
        }

        private static Book CreateDemoBook() =>
        new()
        {
            CoverPhotoUrl = "/Lombiq.TrainingDemo/images/HarryPotter.jpg",
            Title = "Harry Potter and The Sorcerer's Stone",
            Author = "J.K. (Joanne) Rosenzweig",
            Description = "Harry hasn't had a birthday party in eleven years - but all that is about to change " +
                "when a mysterious letter arrives with an invitation to an incredible place.",
        };
    }
}
