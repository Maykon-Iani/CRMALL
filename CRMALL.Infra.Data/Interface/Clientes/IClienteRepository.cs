using CRMALL.Domain.Entities;
using CRMALL.Infra.Data.Interface.Common;
using System.Linq;

namespace CRMALL.Infra.Data.Interface.Clientes
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IQueryable<Cliente> FilterByName(string searchString);
    }
}
