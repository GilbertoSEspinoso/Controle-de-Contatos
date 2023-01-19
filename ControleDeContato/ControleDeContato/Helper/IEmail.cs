namespace ControleDeContato.Helper
{
    public interface IEmail
    {
        bool SendEmail(string email, string assunto, string message);
    }
}
