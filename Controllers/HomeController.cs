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

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 5;

            IQueryable<Books> source = _context.AllBooks.Include(x => x.BookName);
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                MyBooks = items
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string EmpSearch, int page = 1)
        {
            int pageSize = 5;
            ViewData["GetBookDetails"] = EmpSearch;

            var EmpQuery = from x in _context.AllBooks select x;
            if (!String.IsNullOrEmpty(EmpSearch))
            {
                EmpQuery = EmpQuery.Where(x => x.BookName.Contains(EmpSearch) || x.BookAuthor.Contains(EmpSearch));
            }

            var count = await EmpQuery.CountAsync();
            var items = await EmpQuery.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                MyBooks = items
            };

            return View(viewModel);
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