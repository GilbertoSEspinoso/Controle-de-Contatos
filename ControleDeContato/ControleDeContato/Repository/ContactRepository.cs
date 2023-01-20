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
            this._dataContext = dataContext;
        }

        public ContactModel ListForId(int id)
        {
            return _dataContext.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> GetAll(int usuarioId)
        {
            return _dataContext.Contacts.Where(x => x.UsuarioId == usuarioId).ToList();
        }

        public ContactModel AddContact(ContactModel contact)
        {
            //gravar no banco de dados
            _dataContext.Contacts.Add(contact);
            _dataContext.SaveChanges();
            return contact;
        }

        public ContactModel UpdateContact(ContactModel contact)
        {
            ContactModel contactDb = ListForId(contact.Id);


            if (contactDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do contato");
            }
            contactDb.Name = contact.Name;
            contactDb.Email = contact.Email;
            contactDb.Phone = contact.Phone;


            _dataContext.Contacts.Update(contactDb);
            _dataContext.SaveChanges();
            return contactDb;
        }

        public bool Delete(int id)
        {
            ContactModel contactDb = ListForId(id);
            if (contactDb == null)
            {
                throw new System.Exception("Houve um erro ao tentar excluir o contato.");
            }
            _dataContext.Contacts.Remove(contactDb);
            _dataContext.SaveChanges();
            return true;
        }
    }
}
