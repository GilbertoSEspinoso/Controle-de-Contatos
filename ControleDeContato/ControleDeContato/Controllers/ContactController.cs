using ControleDeContato.Filters;
using ControleDeContato.Helper;
using ControleDeContato.Models;
using ControleDeContato.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    [PaginaUsuarioLogado]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ISessao _sessao;

        public ContactController(IContactRepository contactRepository, ISessao sessao)
        {
            _contactRepository = contactRepository;
            _sessao = sessao;
        }


        public IActionResult Index()
        {
            UserModel usuarioLogado = _sessao.SearchUserSession();
            var contacts = _contactRepository.GetAll(usuarioLogado.Id);

            return View(contacts);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListForId(id);
            return View(contact);
        }
        public IActionResult DeleteContact(int id)
        {
            ContactModel contact = _contactRepository.ListForId(id);
            return View(contact);
        }



        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _contactRepository.Delete(id);

                if (deleted)
                {
                    TempData["MensagemSucesso"] = "O Contato foi apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemError"] = "Ops! Não consegui apagar o seu contato.";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Não consegui apagar o seu contato. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuarioLogado = _sessao.SearchUserSession();
                    contact.UsuarioId = usuarioLogado.Id;

                    contact = _contactRepository.AddContact(contact);

                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Cadastro não realizado. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }


        }

        [HttpPost]
        public IActionResult Change(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuarioLogado = _sessao.SearchUserSession();
                    contact.UsuarioId = usuarioLogado.Id;

                    contact = _contactRepository.UpdateContact(contact);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Não foi possível realizar a alteração no contato. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }
        }
    }
}