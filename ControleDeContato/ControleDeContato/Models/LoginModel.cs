using System.ComponentModel.DataAnnotations;

namespace ControleDeContato.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Login inválido!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha inválido!")]
        public string Password { get; set; }
    }
}
