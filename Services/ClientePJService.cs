using CRM.Data;
using CRM.Models;

namespace CRM.Services
{
    public class ClientePJService
    {
        private readonly AppDbContext _context;
        public ClientePJService(AppDbContext context)
        {
            _context = context;
        }

        public List<ClientePJ> GetClientesPJ()
        {
            return _context.ClientePJ.ToList();
        }

        public ClientePJ GetClientesPJId(int id)
        {
            return _context.ClientePJ.FirstOrDefault(u => u.Id == id);
        }

        public ClientePJ CriarClientePJ(ClientePJ novoClientePJ)
        {
            _context.ClientePJ.Add(novoClientePJ);
            _context.SaveChanges();
            return novoClientePJ;
        }

        public bool AtualizarClientePJ(int id, ClientePJ clientePJAtualizado)
        {
            var cliente = _context.ClientePJ.FirstOrDefault(u => u.Id == id);
            if (cliente == null)
            {
                return false;
            }
            else
            {
                
                cliente.Nome = clientePJAtualizado.Nome;
                cliente.CNPJ = clientePJAtualizado.CNPJ;
                cliente.Endereco = clientePJAtualizado.Endereco;
                cliente.Email = clientePJAtualizado.Email;
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeletarClientePJ(int id)
        {
            var cliente = _context.ClientePJ.FirstOrDefault(u => u.Id == id);
            if (cliente == null)
            {
                return false;
            }
            else
            {
                _context.ClientePJ.Remove(cliente);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
