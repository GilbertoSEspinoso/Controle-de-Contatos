using ControleDeContato.Data;
using ControleDeContato.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ControleDeContato.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public UserModel SearchByLogin(string login)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel SearchByEmailAndLogin(string email, string login)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel ListForId(int id)
        {
            return _dataContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> GetAll()
        {
            return _dataContext.Users
                .Include(x => x.Contacts)
                .ToList();
        }

        public UserModel AddUser(UserModel user)
        {
            //gravar no banco de dados
            user.DataRegister = DateTime.Now;
            user.SetSenhaHash();
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
            return user;
        }

        public UserModel UpdateUser(UserModel user)
        {
            UserModel userDb = ListForId(user.Id);
            if (userDb == null)
            {
                throw new System.Exception("Houve um erro na atualização do usuário");
            }
            userDb.Name = user.Name;
            userDb.Email = user.Email;
            userDb.Login = user.Login;
            userDb.Perfil = user.Perfil;
            userDb.DataUpdate = DateTime.Now;


            _dataContext.Users.Update(userDb);
            _dataContext.SaveChanges();
            return userDb;
        }

        public UserModel ChangePassword(ChangePasswordModel changePasswordModel)
        {
            UserModel userDB = ListForId(changePasswordModel.Id);

            if (userDB == null) throw new System.Exception("Houve um erro na atualização da senha, usuário não encontrado");

            if (!userDB.ValidPassword(changePasswordModel.CurrentPassword)) throw new Exception("Senha atual não confere.");

            if (userDB.ValidPassword(changePasswordModel.NewPassword)) throw new Exception("Nova senha deve ser diferente da atual");

            userDB.SetNewPass(changePasswordModel.NewPassword);
            userDB.DataUpdate = DateTime.Now;

            _dataContext.Users.Update(userDB); _dataContext.SaveChanges();

            return userDB;
        }

        public bool DeleteUser(int id)
        {
            UserModel userDB = ListForId(id);
            if (userDB == null)
            {
                throw new System.Exception("Houve um erro ao tentar excluir o usuário.");
            }
            _dataContext.Users.Remove(userDB);
            _dataContext.SaveChanges();
            return true;
        }


    }
}
