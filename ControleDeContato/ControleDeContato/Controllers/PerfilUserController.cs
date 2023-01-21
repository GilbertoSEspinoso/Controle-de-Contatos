using ControleDeContato.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    public class PerfilUserController : Controller
    {

        [PaginaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
