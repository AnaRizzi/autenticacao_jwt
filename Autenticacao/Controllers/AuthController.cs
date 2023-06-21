using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static List<string> Nomes = new List<string>()
        {
            "Ana"
        };

        // POST: <AuthController>/token
        [HttpPost("token")]
        [AllowAnonymous]
        public string PostToken([FromBody] UsuarioToken usuario)
        {
            return Token.GenerateToken(usuario);
        }

        // GET: <AuthController>
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<string> Get()
        {
            return Nomes;
        }

        // POST <AuthController>
        [HttpPost]
        [Authorize]
        public void Post()
        {
            Nomes.Add(User.Identity.Name);
        }

        // DELETE <AuthController>
        [HttpDelete]
        [Authorize(Roles = "adm,administrador")]
        public void Delete()
        {
            Nomes.Remove(User.Identity.Name);
        }
    }
}
