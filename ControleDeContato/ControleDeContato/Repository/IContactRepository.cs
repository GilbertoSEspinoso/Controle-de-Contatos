using ControleDeContato.Models;
using System.Collections.Generic;

namespace ControleDeContato.Repository
{
    public interface IContactRepository
    {
        ContactModel ListForId(int id);
        List<ContactModel> GetAll();
        ContactModel AddContact(ContactModel contact);
        ContactModel UpdateContact(ContactModel contact);
        bool Delete (int id);
    }
}
