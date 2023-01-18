using ControleDeContato.Helper;
using ControleDeContato.Models;
using ControleDeContato.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessao _sessao;

        public LoginController(IUserRepository userRepository, ISessao sessao)
        {
            _userRepository = userRepository;
            _sessao = sessao;
        }



        public IActionResult Index()
        {
            //Se o usuario ja estiver logado, redirecionar para home

            if (_sessao.SearchUserSession() != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult ExitLogin()
        {
            _sessao.RemoveSessionUser();
            return RedirectToAction("Index", "Login"); 
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
                            _sessao.CreateSessionUser(user);
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
