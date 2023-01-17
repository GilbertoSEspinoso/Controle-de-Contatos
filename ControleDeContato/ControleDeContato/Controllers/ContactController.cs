using ControleDeContato.Models;
using ControleDeContato.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }


        public IActionResult Index()
        {
            var contacts = _contactRepository.GetAll();

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
                    _contactRepository.AddContact(contact);
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
                    _contactRepository.UpdateContact(contact);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View("Edit", contact);
            }
            catch (System.Exception e)
            {
                TempData["MensagemError"] = $"Ops! Não foi possível realizar a alteração no contato. Erro: ( {e.Message} )";
                return RedirectToAction("Index");
            }
        }
    }
}