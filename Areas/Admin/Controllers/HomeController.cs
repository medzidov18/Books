using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Data;
using OnlineBooks.Models;

namespace OnlineBooks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(DataManager dataManager, ILogger<HomeController> logger)
        {
            _dataManager = dataManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_dataManager.AllBooks.GetBookItems());
        }

    }
}
