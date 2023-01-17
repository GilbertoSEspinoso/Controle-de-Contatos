using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult DeleteContact()
        {
            return View();
        }
    }
}