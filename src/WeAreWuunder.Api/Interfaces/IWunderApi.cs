using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreWuunder.Api.Models;

namespace WeAreWuunder.Api.Interfaces
{
    [Headers("User-Agent: WeAreWuunderApi Client / C# / Github", "Authorization: Bearer")]
    public interface IWunderApi
    {
     //   [Refit.Get("/api/shipments")]
      //  Task<List<Responses.CreateShipmentResponse>> GetShipments();

        [Refit.Post("/api/shipments")]
        Task<Responses.CreateShipmentResponse> CreateShipment(Requests.CreateShipmentRequest request);
    }
}
