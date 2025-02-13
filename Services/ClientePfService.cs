using CRM.Data;
using CRM.Models;

namespace CRM.Services
{
    public class ClientePfService
    {
        private readonly AppDbContext _context;
        public ClientePfService(AppDbContext context)
        {
            _context = context;
        }

        public List<ClientePf> GetClientes()
        {
            return _context.Clientes.ToList();
        }

        public ClientePf GetClientesId(int id)
        {
            return _context.Clientes.FirstOrDefault(u => u.id == id);
        }

        public ClientePf CriarClientePf(ClientePf novoClientePf)
        {
            _context.Clientes.Add(novoClientePf);
            _context.SaveChanges();
            return novoClientePf;
        }

        public bool AtualizarCliente(int id, ClientePf clientePfAtualizado)
        {
            var cliente = _context.Clientes.FirstOrDefault(u => u.id ==id);
            if (cliente == null)
            {
                return false;
            }
            else
            {
                cliente.nome = clientePfAtualizado.nome;
                cliente.email  = clientePfAtualizado.email;
                cliente.cpf = clientePfAtualizado.cpf;
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeletarClientePf(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(u => u.id == id);
            if (cliente == null)
            {
                return false;
            }
            else
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
