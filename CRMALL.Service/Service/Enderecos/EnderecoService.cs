using CRMALL.Domain.Entities;
using CRMALL.Infra.Data.Interface.Enderecos;
using CRMALL.Service.Interface.Enderecos;

namespace CRMALL.Service.Service.Enderecos
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;
        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void AddOrEdit(Endereco endereco)
        {
            if (endereco.Id > 0)
                _enderecoRepository.Update(endereco);
            else
                _enderecoRepository.Add(endereco);

            _enderecoRepository.SaveChanges();
        }

        public void Delete(long id)
        {
            var endereco = _enderecoRepository.GetById(id);

            _enderecoRepository.Delete(endereco);
            _enderecoRepository.SaveChanges();
        }
    }
}
