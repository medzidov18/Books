using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using OnlineBooks.Data;
using OnlineBooks.Models;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Text;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Hosting.Server;

namespace OnlineBooks.Controllers
{
    public class ReadController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;
        public ReadController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index(Guid? id, int page = 1)
        {
            if (id == null)
            {
                return NotFound();
            }

            int pageSize = 120;
          
            Books Book = _context.AllBooks.Find(id);
            string[] text = System.IO.File.ReadAllLines($@"C:\Users\Asus\Projects\OnlineBooks\OnlineBooks\wwwroot\files\{Book.BookFilePath}");
            var count = text.Length;
            var items = text.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.Data = items;
            ViewBag.Book = Book;
            ViewBag.Page = page;

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            TextViewModel viewModel = new TextViewModel()
            {
                PageViewModel = pageViewModel,
                MyBook = Book
            };
            
            return View(viewModel);
        }
    }
}
