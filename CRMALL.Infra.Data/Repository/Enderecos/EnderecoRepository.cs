using CRMALL.Domain.Entities;
using CRMALL.Infra.Data.Context;
using CRMALL.Infra.Data.Interface.Enderecos;
using CRMALL.Infra.Data.Repository.Common;

namespace CRMALL.Infra.Data.Repository.Enderecos
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataContext context) : base(context)
        {
        }
    }
}
