using CRMALL.Domain.Entities;
using System.Linq;

namespace CRMALL.Service.Interface.Clientes
{
    public interface IClienteService
    {
        IQueryable<Cliente> GetAll();
        Cliente GetById(long id);
        void AddOrEdit(Cliente cliente);
        void Delete(long id);
        IQueryable<Cliente> FilterByName(string searchString);
    }
}
