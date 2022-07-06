using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Data;
using OnlineBooks.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace OnlineBooks.Controllers
{
    public class ReadController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReadController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Book = _context.AllBooks.Find(id);
            string path = $@"C:\Users\Asus\Projects\OnlineBooks\OnlineBooks\wwwroot\files\{Book.BookFilePath}";

            Response.Write("some text");

            return View();
        }
    }
}
