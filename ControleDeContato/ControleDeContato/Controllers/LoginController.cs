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
        private readonly IEmail _email;

        public LoginController(IUserRepository userRepository, ISessao sessao, IEmail email)
        {
            _userRepository = userRepository;
            _sessao = sessao;
            _email = email;
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

        public IActionResult RedefinirSenha()
        {
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


        [HttpPost]
        public IActionResult EnviarLinkRedefinirSenha(RedefinirSenhaModel redefinirSenhaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //este metedo busca usuario no banco
                    UserModel user = _userRepository.SearchByEmailAndLogin(redefinirSenhaModel.Email, redefinirSenhaModel.Login);

                    if (user != null)
                    {
                        string newPassword = user.GenerateNewPassword();
                        string message = $"Sua nova senha é: {newPassword}";

                        bool emailEnviado = _email.SendEmail(user.Email, "Sistema de agenda de contatos - Nova Senha", message);

                        if (emailEnviado)
                        {
                            _userRepository.UpdateUser(user);
                            TempData["MensagemSucesso"] = "Enviamos para o seu emial cadastrado uma nova senha";
                        }
                        else
                        {

                            TempData["MensagemError"] = "Não foi possível enviar uma nova senha para o seu e-mail. Por favor tente novamente.";
                        }


                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemError"] = "Não foi possível! Verifique corretamente os dados informados.";

                }

                return View("Index");
            }

            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Não consegui redefinir sua senha. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }
        }
    }
}
