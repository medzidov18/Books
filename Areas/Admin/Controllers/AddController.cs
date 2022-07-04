using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Data;
using OnlineBooks.Models;
using OnlineBooks.Service;

namespace OnlineBooks.Areas.Admin.Controllers
{
    public class AddController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;
        public AddController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Books() : dataManager.AllBooks.GetBookItemById(id);
            return View(entity);
        }

        [HttpPost]
        public IActionResult Edit(Books model, IFormFile fileOfBook)
        {
            if (ModelState.IsValid)
            {
                if (fileOfBook != null)
                {
                    model.BookFilePath = fileOfBook.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "C:/Users/Asus/Books/", fileOfBook.FileName), FileMode.Create))
                    {
                        fileOfBook.CopyTo(stream);
                    }
                }
                dataManager.AllBooks.SaveBooks(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.AllBooks.DeleteBook(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
