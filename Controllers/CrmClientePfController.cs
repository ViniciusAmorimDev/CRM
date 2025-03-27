using CRM.Models;
using CRM.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CRMClientePfController : ControllerBase
    {
        private readonly ClientePfService _clienteService;

        public CRMClientePfController(ClientePfService clienteservice)
        {
            _clienteService = clienteservice;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ClientePf>> GetClientesPf()
        {
            try
            {
                return Ok(_clienteService.GetClientes());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel obter a listagem de clientes PF: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClientePf> GetClientePfId(int id)
        {
            try
            {
                var cliente = _clienteService.GetClientesId(id);
                if (cliente == null)
                {
                    return NotFound("Usuario nao encontrado");
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel encontrar o cliente PF: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<ClientePf> CriarClientePf([FromBody] ClientePf novoClientePf)
        {
            try
            {
                if (novoClientePf == null)
                {
                    return BadRequest("Dados invalidos");
                }
                else
                {
                    var clienteCriado = _clienteService.CriarClientePf(novoClientePf);
                    return CreatedAtAction(nameof(GetClientePfId), new { id = clienteCriado.id }, clienteCriado);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel criar o novo cliente PJ: {ex.Message}");
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarClientePf(int id, [FromBody] ClientePf clientePfAtualizado)
        {
            try
            {
                var atualizado = _clienteService.AtualizarCliente(id, clientePfAtualizado);
                if (!atualizado)
                {
                    return NotFound("Cliente n�o encontrado");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel atualizar o cliente PF: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarClientePf(int id)
        {
            try
            {
                var deletado = _clienteService.DeletarClientePf(id);
                if (!deletado)
                {
                    return NotFound("Cliente n�o encontrado");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Não foi possivel deletar o cliente PF: {ex.Message}");
            }
        }

    }
}
