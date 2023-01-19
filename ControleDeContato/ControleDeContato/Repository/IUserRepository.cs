using ControleDeContato.Models;
using System.Collections.Generic;

namespace ControleDeContato.Repository
{
    public interface IUserRepository
    {
        UserModel SearchByLogin(string login);
        UserModel SearchByEmailAndLogin(string email, string login);
        UserModel ListForId(int id);
        List<UserModel> GetAll();
        UserModel AddUser(UserModel user);
        UserModel UpdateUser(UserModel user);
        bool Delete(int id);
    }
}
