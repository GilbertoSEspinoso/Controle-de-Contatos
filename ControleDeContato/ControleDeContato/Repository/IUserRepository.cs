using ControleDeContato.Models;
using System.Collections.Generic;

namespace ControleDeContato.Repository
{
    public interface IUserRepository
    {
        UserModel ListForId(int id);
        List<UserModel> GetAll();
        UserModel AddUser(UserModel user);
        UserModel UpdateUser(UserModel user);
        bool Delete(int id);
    }
}
