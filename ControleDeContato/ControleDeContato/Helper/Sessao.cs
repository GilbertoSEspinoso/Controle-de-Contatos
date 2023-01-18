using ControleDeContato.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ControleDeContato.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        //buscar a sessão do usuário
        public UserModel SearchUserSession()
        {
            string sessionUser = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if(string.IsNullOrEmpty(sessionUser))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<UserModel>(sessionUser);
        }

        //criar a sessão do usuário
        public void CreateSessionUser(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", value);
        }

        //remover a sessão do usuário
        public void RemoveSessionUser()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }

        
    }
}
