using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Models;
using System.Diagnostics;
using OnlineBooks.Data;

namespace OnlineBooks.Controllers
{
    
    public class HomeController : Controller
    {
        List<Books> books;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}