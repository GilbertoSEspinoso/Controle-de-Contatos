using System.ComponentModel.DataAnnotations;

namespace ControleDeContato.Models
{
    public class ChangePasswordModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite a senha atual do usuário")]
        public string CurrentPassword{ get; set; }

        [Required(ErrorMessage = "Digite a senha nova do usuário")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirme a senha nova do usuário")]
        [Compare("NewPassword", ErrorMessage ="Senha não confere com a nova senha")]
        public string ConfirmNewPassword { get; set; }
       

    }
}
