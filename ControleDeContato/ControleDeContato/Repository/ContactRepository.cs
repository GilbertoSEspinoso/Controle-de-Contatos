using ControleDeContato.Data;
using ControleDeContato.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContato.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly DataContext _dataContext;
        public ContactRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<ContactModel> GetAll()
        {
            return _dataContext.Contacts.ToList();
        }

        public ContactModel AddContact(ContactModel contact)
        {
            //gravar no banco de dados
            _dataContext.Contacts.Add(contact);
            _dataContext.SaveChanges();
            return contact;
        }

       
    }
}
