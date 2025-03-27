using CRM.Models;
using CRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CrmClientePJController : ControllerBase
    {
        private readonly ClientePJService _clientePJService;

        public CrmClientePJController(ClientePJService clientepjservice)
        {
            _clientePJService = clientepjservice;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientePJ>> GetClientePJ()
        {
            try
            {
                return Ok(_clientePJService.GetClientesPJ());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível obter a listagem de clientes PJ: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClientePJ> GetClientePJId( int id) 
        {
            try
            {
                var cliente = _clientePJService.GetClientesPJId(id);
                if (cliente == null)
                {
                    return NotFound("Usuário não encontrado.");
                }
                return Ok(cliente);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Não foi possível encontrar o cliente PJ: {ex.Message}");
            }
        
        }

        [HttpPost]
        public ActionResult<ClientePJ> CriarClientePJ([FromBody] ClientePJ novoClientePJ)
        {
            try
            {
                if (novoClientePJ == null)
                {
                    return BadRequest("Dados invalidos");
                }
                else
                {
                    var clienteCriado = _clientePJService.CriarClientePJ(novoClientePJ);
                    return CreatedAtAction(nameof(GetClientePJId), new { id = clienteCriado.Id }, clienteCriado);
                }
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Não foi possível criar o novo cliente PJ: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarClientePJ(int id, [FromBody] ClientePJ clientePjAtualizado)
        {
            try
            {
                var atualizado = _clientePJService.AtualizarClientePJ(id, clientePjAtualizado);
                if (!atualizado)
                {
                    return NotFound("Cliente nao encontrado.");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possível atualizar o cliente PJ: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarClientePJ(int id)
        {
            try
            {
                var deletado = _clientePJService.DeletarClientePJ(id);
                if(!deletado)
                {
                    return NotFound("Cliente nao encontrado.");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel deletar o cliente PJ: {ex.Message}");
            }
        }
    }
}
