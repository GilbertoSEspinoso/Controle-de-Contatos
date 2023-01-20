using ControleDeContato.Enums;
using ControleDeContato.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContato.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o seu nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }

        [EmailAddress(ErrorMessage = "Digite um e-mail válido!")]
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Perfil do usuário")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Password { get; set; }


        public DateTime DataRegister { get; set; }
        public DateTime? DataUpdate { get; set; }

        public bool ValidPassword(string password)
        {
            return Password == password.GerarHash();
        }
        public void SetSenhaHash()
        {
            Password = Password.GerarHash();
        }

        public void SetNewPass(string newPassword)
        {
            Password = newPassword.GerarHash();
        }

        public string GenerateNewPassword()
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            Password = newPassword.GerarHash();
            return newPassword;
        }
    }
}
