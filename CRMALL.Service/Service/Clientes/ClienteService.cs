using CRMALL.Domain.Entities;
using CRMALL.Infra.Data.Interface.Clientes;
using CRMALL.Service.Interface.Clientes;
using CRMALL.Service.Interface.Enderecos;
using System.Linq;

namespace CRMALL.Service.Service.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoService _enderecoService;

        public ClienteService(IEnderecoService enderecoService,
                              IClienteRepository clienteRepository)
        {
            _enderecoService = enderecoService;
            _clienteRepository = clienteRepository;
        }

        public IQueryable<Cliente> GetAll()
        {
            return
                _clienteRepository.Get(null, null, x => x.Endereco);

        }

        public Cliente GetById(long id)
        {
            return
                _clienteRepository.GetFirstOrDefault(_cliente => _cliente.Id == id,
                                                     includes => includes.Endereco);
        }

        public void AddOrEdit(Cliente cliente)
        {
            if (cliente.Endereco != null)
                _enderecoService.AddOrEdit(cliente.Endereco);


            if (cliente.Id > 0)
                _clienteRepository.Update(cliente);
            else
                _clienteRepository.Add(cliente);

            _clienteRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            var cliente = _clienteRepository.GetById(id);

            _clienteRepository.Delete(cliente);
            _clienteRepository.SaveChanges();

            if (cliente.Endereco != null)
                _enderecoService.Delete(cliente.Endereco.Id);            
        }

        public IQueryable<Cliente> FilterByName(string searchString)
        {
            return
                _clienteRepository.FilterByName(searchString);
        }
    }
}
