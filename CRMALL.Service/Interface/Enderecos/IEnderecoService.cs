using CRMALL.Domain.Entities;

namespace CRMALL.Service.Interface.Enderecos
{
    public interface IEnderecoService
    {
        void AddOrEdit(Endereco endereco);
        void Delete(long id);
    }
}
