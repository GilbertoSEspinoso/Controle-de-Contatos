using System.ComponentModel.DataAnnotations;

namespace ControleDeContato.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage ="Digite um e-mail válido!")]
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }

        [Phone(ErrorMessage ="Digite um número válido!")]
        [Required(ErrorMessage = "Digite o número para contato")]
        public string Phone { get; set; }
    }
}
