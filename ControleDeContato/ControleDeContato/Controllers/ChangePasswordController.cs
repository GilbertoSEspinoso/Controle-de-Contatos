using ControleDeContato.Helper;
using ControleDeContato.Models;
using ControleDeContato.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessao _sessao;

        public ChangePasswordController(IUserRepository userRepository, ISessao sessao)
        {
            _userRepository = userRepository;
            _sessao = sessao;
        }



        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Change(ChangePasswordModel changePasswordModel)
        {
            try
            {
                // pegando a Id do usuario Logado na sessao e atribuir no changePassword
                UserModel usuarioLogado = _sessao.SearchUserSession();
                changePasswordModel.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {

                    _userRepository.ChangePassword(changePasswordModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", changePasswordModel);
                }

                return View("Index", changePasswordModel);
            }
            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Não conseguimos alterar a sua senha.Tente novamente.Erro:({e.Message})";
                return View("Index", changePasswordModel);
            }
        }
    }
}
