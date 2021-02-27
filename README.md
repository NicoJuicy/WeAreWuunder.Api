# WeAreWuunder.Api

## Usage

- Install the [nuget package: WeAreWuunder.Api](https://www.nuget.org/packages/WeAreWuunder.Api)

- Create the client:

      var client = new WeAreWuunderApiClient(Environment.Production, "{your-api-key}");

- Create the shipment

      var response = await client.CreateShipment(request);

## Notes

See the [WuunderApi docs](https://wearewuunder.com/handleiding/technical-manual-book-shipments-api/)

Example on which values to fill, can be found in the Integration Test
