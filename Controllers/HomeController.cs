using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        public async Task<IActionResult> Index(string EmpSearch)
        {
            ViewData["GetBookDetails"] = EmpSearch;

            var EmpQuery = from x in _context.AllBooks select x;
            if (!String.IsNullOrEmpty(EmpSearch))
            {
                EmpQuery = EmpQuery.Where(x => x.BookName.Contains(EmpSearch) || x.BookAuthor.Contains(EmpSearch));
            }
            return View(await EmpQuery.AsNoTracking().ToListAsync());
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