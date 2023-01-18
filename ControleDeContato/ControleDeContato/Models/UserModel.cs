using ControleDeContato.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContato.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o seu nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o Login do usuário")]
        public string Login { get; set; }

        [EmailAddress(ErrorMessage = "Digite um e-mail válido!")]
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Password { get; set; }


        public DateTime DataRegister { get; set; }
        public DateTime? DataUpdate { get; set; }
    }
}
