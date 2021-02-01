# WeAreWuunder.Api

## Installation

Todo when this api is final

## Usage

- Create the client:

      var client = new WeAreWuunderApiClient(Models.Environment.Production, "{your-api-key}");

- Create the shipment

      var response = await client.CreateShipment(request);
