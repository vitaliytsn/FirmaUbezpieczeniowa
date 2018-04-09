using System;
using System.Linq;
using System.Threading.Tasks;
using Insurinator.DataAccess.Services;
using Insurinator.Models.Entities;
using Insurinator.Models.Entities.InsuranceEntries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Insurinator.DatabaseTests
{
    [TestClass]
    public class ClientTests
    {
        public ClientTests()
        {
            using (var service = new ClientsService())
            {
                service.DropAll();
            }
        }

        private async Task<Client> AddTestClient(ClientsService service)
        {
            var c = service.Add(new Client { Name = "Test", Surname = "Test", Email = "q@w.e" });
            await service.SaveChangesAsync();
            return c;
        }

        [TestMethod]
        public async Task TestAddingClient()
        {
            var service = new ClientsService();

            await AddTestClient(service);

            var client = await service.FirstAsync(c => c.Name == "Test");
            Assert.IsTrue(client != null);

            service.Dispose();
        }

        [TestMethod]
        public async Task TestUpdatingClient()
        {
            var service = new ClientsService();

            await AddTestClient(service);

            var client = await service.FirstAsync(c => c.Name == "Test");
            client.Name = "Test1Updated";
            service.Update(client);
            await service.SaveChangesAsync();

            client = await service.FirstAsync(c => c.Name == "Test1Updated");
            Assert.IsTrue(client != null);

            service.Dispose();
        }

        [TestMethod]
        public async Task TestAddingInsurance()
        {
            var service = new ClientsService();

            var client = await AddTestClient(service);

            client.Insurances.Add(new VehicleInsuranceEntry {CarPlate = "TST101010"});

            await service.SaveChangesAsync();

            client = await service.FirstAsync(c => c.Name == "Test");
            Assert.IsTrue(client.Insurances.Any());

            service.Dispose();
        }
    }
}
