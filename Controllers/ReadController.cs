using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using OnlineBooks.Data;
using OnlineBooks.Models;
using System;
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

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Book = _context.AllBooks.Find(id);
            string[] text = System.IO.File.ReadAllLines($@"C:\Users\Asus\Projects\OnlineBooks\OnlineBooks\wwwroot\files\{Book.BookFilePath}");
            ViewBag.Data = text;
            ViewBag.Book = Book;

            return View();
        }
    }
}
