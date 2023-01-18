using ControleDeContato.Models;
using ControleDeContato.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StartLogin(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.SearchByLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.ValidPassword(loginModel.Password))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemError"] = "Senha inválida!";
                    }

                    TempData["MensagemError"] = "Usuário ou Senha inválidos!";

                }

                return View("Index");
            }

            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Não consegui realizar o seu login. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }
        }
    }
}
