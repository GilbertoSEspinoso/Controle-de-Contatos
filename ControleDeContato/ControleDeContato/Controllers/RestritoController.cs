using ControleDeContato.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
