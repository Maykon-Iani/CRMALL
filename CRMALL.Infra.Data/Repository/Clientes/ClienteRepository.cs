using CRMALL.Domain.Entities;
using CRMALL.Infra.Data.Context;
using CRMALL.Infra.Data.Interface.Clientes;
using CRMALL.Infra.Data.Repository.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CRMALL.Infra.Data.Repository.Clientes
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DataContext context) : base(context) { }

        public IQueryable<Cliente> FilterByName(string searchString) => _context.Clientes
                                                                                   .Include(c => c.Endereco)
                                                                                   .Where(c => c.Nome.Contains(searchString));
    }
}
