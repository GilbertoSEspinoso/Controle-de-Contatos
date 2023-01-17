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
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.AddContact(contact);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Change(ContactModel contact)
        {
            _contactRepository.UpdateContact(contact);
            return RedirectToAction("Index");
        }
    }
}