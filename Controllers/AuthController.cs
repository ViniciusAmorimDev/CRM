using CRM.Models;
using CRM.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User usuario)
        {
            if (usuario.Email == "teste@teste.com" && usuario.Senha == "123456")
            {
                var token = _tokenService.GerarToken(usuario.Email);
                return Ok(new { token });
            }

            return Unauthorized("Credenciais inválidas");
        }
    }
}
