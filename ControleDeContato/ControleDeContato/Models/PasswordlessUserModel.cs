using ControleDeContato.Enums;
using System.ComponentModel.DataAnnotations;
using System;

namespace ControleDeContato.Models
{
    public class PasswordlessUserModel
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

       
    }
}

