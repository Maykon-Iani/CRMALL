using CRMALL.Infra.Data.Context;
using CRMALL.Infra.Data.Interface.Clientes;
using CRMALL.Infra.Data.Interface.Enderecos;
using CRMALL.Infra.Data.Repository.Clientes;
using CRMALL.Infra.Data.Repository.Enderecos;
using CRMALL.Service.Interface.Clientes;
using CRMALL.Service.Interface.Enderecos;
using CRMALL.Service.Service.Clientes;
using CRMALL.Service.Service.Enderecos;
using Microsoft.Extensions.DependencyInjection;

namespace CRMALL.Infra.CrossCutting.IoC.Injector
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Context dependency
            services.AddDbContext<DataContext>();

            // Service
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEnderecoService, EnderecoService>();

            // Repository
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
        }
    }
}
