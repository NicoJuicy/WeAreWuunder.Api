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
            client = new WeAreWuunderApiClient(Models.Environment.Production, "{ add-api-key}");
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

            var orderLine = new Bogus.Faker<Models.OrderLine>()
                .RuleFor(ol => ol.CountryOfOrigin, f => "BE")
                .RuleFor(ol => ol.Description, f => f.Commerce.ProductDescription())
                .RuleFor(ol => ol.SKU, f => f.Commerce.Ean13())
                .RuleFor(ol => ol.EAN, f => f.Commerce.Ean13())
                .RuleFor(ol => ol.HsCode, f => 22030001)
                .RuleFor(ol => ol.Weight, f => f.Random.Int(200,1000))
                .RuleFor(ol => ol.Value, f => f.Finance.Amount(5, 20, 2))
                .RuleFor(ol => ol.Quantity, f => f.Random.Int(1,5));


            var lorem = new Bogus.DataSets.Lorem(locale: "en");

//           var orderLines = new Bogus.Faker<List<Models.OrderLine>>()
                
            var orderlines = orderLine.Generate(3);

            var generateShipment = new Bogus.Faker<Requests.CreateShipmentRequest>()
                .RuleFor(s => s.Description, f => lorem.Sentence(1))
                .RuleFor(s => s.DeliveryAddress, f => address.Generate())
                .RuleFor(s => s.PickupAddress, f => address.Generate())
                .RuleFor(s => s.PreferredServiceLevel, f => Models.Constants.ShippingServiceLevels.Where(dl => dl.Contains("dpd") && dl.Contains("cheap")).FirstOrDefault()) // f.PickRandom(Models.Constants.ShippingServiceLevels)
                .RuleFor(s => s.Kind, "package")
                .RuleFor(s => s.Value, f => f.Random.Int(1,50))
                .RuleFor(s => s.OrderLines, f => orderlines)
                .RuleFor(s => s.NumberOfItems, f => orderlines.Sum(dl => dl.Quantity))
                .RuleFor(s => s.Length, f => 35)
                .RuleFor(s => s.Width, f => 35)
                .RuleFor(s => s.Height, f => 35)
                .RuleFor(s => s.Weight, f => orderlines.Sum(dl => dl.Quantity * dl.Weight));

            var request = generateShipment.Generate();

            var response = await client.CreateShipment(request);
            Assert.IsNotNull(response);
        }



    }
}
