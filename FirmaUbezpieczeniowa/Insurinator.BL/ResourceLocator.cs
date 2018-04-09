using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Insurinator.DataAccess.Services;
using Insurinator.Interfaces.Services;

namespace Insurinator.BL
{
    public static class ResourceLocator
    {
        public delegate void AdapterRegistration(ContainerBuilder builder);

        private static ILifetimeScope _container;

        public static void RegisterDependencies(AdapterRegistration adapterDelegate)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EmployeesService>().As<IEmployeesService>();
            builder.RegisterType<ClientsService>().As<IClientsService>();
            builder.RegisterType<PropertyInsuranceDefinitionService>().As<IPropertyInsuranceDefinitionService>();
            builder.RegisterType<VehicleInsuranceDefinitionService>().As<IVehicleInsuranceDefinitionService>();

            adapterDelegate(builder);

            _container = builder.Build().BeginLifetimeScope();


        }

        public static ILifetimeScope ObtainScope() => _container.BeginLifetimeScope();
    }
}
