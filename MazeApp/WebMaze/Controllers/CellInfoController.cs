using Microsoft.AspNetCore.Mvc;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class CellInfoController : Controller
    {
        [HttpGet]
        public IActionResult AddCell()
        {
            var model = new CellInfoViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCell(CellInfoViewModel model)
        {
            return View("/Views/CellInfo/BaseCell.cshtml", model);
        }

        public IActionResult Trap()
        {
            var model = new CellInfoViewModel();

            model.CanStep = false;
            model.ImageUrl = "/images/cells/trap.webp";
            model.Description = "Bad cell. Trap";

            return View(model);
        }

    }
}
