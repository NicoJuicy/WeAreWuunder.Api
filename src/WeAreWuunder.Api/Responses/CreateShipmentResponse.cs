using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreWuunder.Api.Requests;

namespace WeAreWuunder.Api.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// label_url and track_and_trace_url will not be available immediately, but only after the shipment is fully processed.
    /// picture_url will contain a publicly accessible link pointing to the picture supplied in the payload, if any.
    /// 
    /// Errors:
    /// 422    Shipment was invalid, for example missing required fields.
    /// 5xx    The Shipment was valid but could not be processed for whatever reason. Clients should retry later.
    /// </remarks>
    public class CreateShipmentResponse : CreateShipmentRequest
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label_url")]
        public string LabelUrl { get; set; }
        [JsonProperty("track_and_trace_url")]
        public string TrackAndTraceUrl { get; set; }

        [JsonProperty("picture_url")]
        public string PictureUrl { get; set; }


        public List<TrackAndTraceDetail> Details { get; set; }

    }

    public class TrackAndTraceDetail
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("track_and_trace_code")]
        public string TrackAndTraceCode { get; set; }


        [JsonProperty("correlation_id")]
        public string CorrelationId { get; set; }
    }
}
