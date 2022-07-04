using Microsoft.AspNetCore.Mvc;
using OnlineBooks.Data;

namespace OnlineBooks.Controllers
{
    public class OnlineBookController : Controller
    {
        private readonly DataManager dataManager;

        public OnlineBookController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.AllBooks.GetBookItemById(id));
            }
            
            return View(dataManager.AllBooks.GetBookItems());
        }
    }
}
