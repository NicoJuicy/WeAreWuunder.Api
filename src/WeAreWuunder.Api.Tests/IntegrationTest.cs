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
        public async Task TestCreateValidBelgianShipment()
        {
            var address = new Bogus.Faker<Models.Address>()
                .RuleFor(a => a.EmailAddress, f => f.Internet.ExampleEmail())
                .RuleFor(a => a.Country, f => "BE")
         .RuleFor(a => a.StreetName, f => "Rue Brederode")
                .RuleFor(a => a.Locality, f => "Brussel")
                .RuleFor(a => a.ZipCode, f => "1000")
                .RuleFor(a => a.HouseNumber, f => "16")
                .RuleFor(a => a.EoriNumber, f => "BE1682949223")
               .RuleFor(a => a.VatNumber, f => "BE1682949223")
                .RuleFor(a => a.Givenname, f => f.Name.FirstName())
                .RuleFor(a => a.FamilyName, f => f.Name.LastName());

            var orderLine = new Bogus.Faker<Models.OrderLine>()
                .RuleFor(ol => ol.CountryOfOrigin, f => "BE")
                .RuleFor(ol => ol.Description, f => f.Commerce.ProductDescription())
                .RuleFor(ol => ol.SKU, f => f.Commerce.Ean13())
                .RuleFor(ol => ol.EAN, f => f.Commerce.Ean13())
                .RuleFor(ol => ol.HsCode, f => "22030001")
                .RuleFor(ol => ol.Weight, f => f.Random.Int(200,1000))
                .RuleFor(ol => ol.Value, f => f.Finance.Amount(5, 20, 2) * 100)
                .RuleFor(ol => ol.Quantity, f => f.Random.Int(1,5));


            var lorem = new Bogus.DataSets.Lorem(locale: "en");
              var orderlines = orderLine.Generate(3);

            var generateShipment = new Bogus.Faker<Requests.CreateShipmentRequest>()
                .RuleFor(s => s.Description, f => lorem.Sentence(1))
                .RuleFor(s => s.DeliveryAddress, f => address.Generate())
                .RuleFor(s => s.PreferredServiceLevel, f => Models.Constants.ShippingServiceLevels.Where(dl => dl.Contains("dpd") && dl.Contains("be") && dl.Contains("cheap")).FirstOrDefault()) // f.PickRandom(Models.Constants.ShippingServiceLevels)
                .RuleFor(s => s.Kind, "package")
                .RuleFor(s => s.Value, f => f.Random.Int(1, 50))
                .RuleFor(s => s.OrderLines, f => orderlines)
                .RuleFor(s => s.NumberOfItems, f => orderlines.Sum(dl => dl.Quantity))
                .RuleFor(s => s.Length, f => 35)
                .RuleFor(s => s.Width, f => 35)
                .RuleFor(s => s.Height, f => 35)
                .RuleFor(s => s.Weight, f => orderlines.Sum(dl => dl.Quantity * dl.Weight));

            

            var request = generateShipment.Generate();

            foreach(var reqItem in request.OrderLines)
            {
                if(!string.IsNullOrEmpty(reqItem.HsCode) && reqItem.HsCode.ToString().Length  ==8)
                {
                    reqItem.HsCode =  "00" + reqItem.HsCode;
                }
            }

            var response = await client.CreateShipment(request);
            Assert.IsNotNull(response);
        }



    }
}
