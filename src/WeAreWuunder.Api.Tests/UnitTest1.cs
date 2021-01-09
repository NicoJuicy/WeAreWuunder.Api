using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WeAreWuunder.Api.Tests
{

    [TestClass]
    public class IntegrationTest
    {
        private Interfaces.IWunderApi client;

        [TestInitialize]
        public void Init()
        {
            client = new WeAreWuunderApiClient(Models.Environment.Staging, "");//"{ add-api-key}");
        }

        [TestMethod]
        public async Task TestCreateInvalidShipment()
        {
            await Assert.ThrowsExceptionAsync<Exceptions.WeAreWuunderApiException>(() => client.CreateShipment(new Requests.CreateShipmentRequest()));
        }

        [TestMethod]
        public async Task TestCreateValidShipment()
        {
            var address = new Bogus.Faker<Models.Address>()
                .RuleFor(a => a.EmailAddress, f => f.Internet.ExampleEmail())
                .RuleFor(a => a.Country, f => "BE")
                .RuleFor(a => a.StreetName, f => f.Address.StreetName())
                .RuleFor(a => a.Locality, f => f.Address.City())
                .RuleFor(a => a.ZipCode, f => f.Address.ZipCode())
                .RuleFor(a => a.HouseNumber, f => f.Address.BuildingNumber())
                .RuleFor(a => a.Givenname, f => f.Name.FirstName())
                .RuleFor(a => a.FamilyName, f => f.Name.LastName());

            var generateShipment = new Bogus.Faker<Requests.CreateShipmentRequest>()
                .RuleFor(s => s.Description, f => f.Random.String())
                .RuleFor(s => s.DeliveryAddress, f => address.Generate())
                .RuleFor(s => s.PickupAddress, f => address.Generate())
                .RuleFor(s => s.PreferredServiceLevel, f => f.PickRandom(Models.Constants.ShippingServiceLevels))
                .RuleFor(s => s.Kind, "package")
                .RuleFor(s => s.NumberOfItems, f => 1)
                .RuleFor(s => s.Length, f => 35)
                .RuleFor(s => s.Width, f => 35)
                .RuleFor(s => s.Height, f => 35)
                .RuleFor(s => s.Weight, f => 30 * 1000);

            var request = generateShipment.Generate();

            var response = await client.CreateShipment(request);
            Assert.IsNotNull(response);
        }



    }
}
