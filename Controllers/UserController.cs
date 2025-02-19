using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    [Authorize] // 🔐 Essa API agora só pode ser acessada com token válido
    public class UsuarioController : ControllerBase
    {
        [HttpGet("perfil")]
        public IActionResult Perfil()
        {
            var email = User.Identity.Name;
            return Ok(new { email, mensagem = "Você acessou um endpoint protegido!" });
        }
    }
}
