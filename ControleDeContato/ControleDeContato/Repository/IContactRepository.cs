using ControleDeContato.Models;
using System.Collections.Generic;

namespace ControleDeContato.Repository
{
    public interface IContactRepository
    {
        List<ContactModel> GetAll();
        ContactModel AddContact(ContactModel contact);
    }
}
