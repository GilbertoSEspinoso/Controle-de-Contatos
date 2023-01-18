using ControleDeContato.Models;

namespace ControleDeContato.Helper
{
    public interface ISessao
    {
        void CreateSessionUser(UserModel user);
        void RemoveSessionUser();
        UserModel SearchUserSession();
    }
}
