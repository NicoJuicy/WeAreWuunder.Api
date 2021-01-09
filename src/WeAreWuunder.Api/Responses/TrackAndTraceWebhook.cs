using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreWuunder.Api.Responses
{
    public class TrackAndTraceWebhook
    {
        /// <summary>
        /// Eg. track_and_trace_updated
        /// </summary>
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("track_and_trace_code")]
        public string TrackAndTraceCode { get; set; }

        [JsonProperty("carrier_code")]
        public string CarrierCode { get; set; }

        [JsonProperty("carrier_name")]
        public string CarrierName { get; set; }

        /// <summary>
        /// JWT Token
        /// </summary>
        [JsonProperty("authentication_token")]
        public string AuthenticationToken { get; set; }
    }
}
