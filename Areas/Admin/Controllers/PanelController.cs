using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Data;
using OnlineBooks.Models;
using OnlineBooks.Service;

namespace OnlineBooks.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PanelController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

            public PanelController(DataManager dataManager, IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
            {
                _dataManager = dataManager;
                _hostingEnvironment = hostingEnvironment;
                _context = context;
            }

            public IActionResult Edit(Guid id)
            {
                var entity = id == default ? new Books() : _dataManager.AllBooks.GetBookItemById(id);
                return View(entity);
            }


            [HttpPost]
            public async Task<IActionResult> Edit(Books model, IFormFile fileOfBook, IFormFile imageOfBook)
            {
            
                    model.BookFilePath = fileOfBook.FileName;
                    model.ImageFilePath = imageOfBook.FileName;

                    using (var streamImage = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "images/", imageOfBook.FileName), FileMode.Create))
                    {
                        imageOfBook.CopyToAsync(streamImage);
                    }
                    
                    using (var streamText = new FileStream(Path.Combine(_hostingEnvironment.WebRootPath, "files/", fileOfBook.FileName), FileMode.Create))
                    {
                        await fileOfBook.CopyToAsync(streamText);
                    }

                    _dataManager.AllBooks.SaveBooks(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
                return View(model);
        }

            [HttpPost]
            public IActionResult Delete(Guid id)
            {
                _dataManager.AllBooks.DeleteBook(id);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
    }
}
