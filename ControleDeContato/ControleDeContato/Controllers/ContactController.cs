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
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult DeleteContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            _contactRepository.AddContact(contact);
            return RedirectToAction("Index");
        }
    }
}