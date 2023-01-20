using ControleDeContato.Models;
using System.Collections.Generic;

namespace ControleDeContato.Repository
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll(int usuarioId);
        ContactModel ListForId(int id);
        ContactModel AddContact(ContactModel contact);
        ContactModel UpdateContact(ContactModel contact);
        bool Delete (int id);
    }
}
