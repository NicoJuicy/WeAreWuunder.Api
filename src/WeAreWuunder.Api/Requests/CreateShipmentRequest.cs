using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreWuunder.Api.Models;

namespace WeAreWuunder.Api.Requests
{
    public class CreateShipmentRequest
    {
        /// <summary>
        /// Description of the contents of the shipment in 50 characters or less.
        /// </summary>
        [Required]
        [JsonProperty("description")]
        public string Description { get; set; }
        /// <summary>
        /// Value of the whole package, VAT excluded, in eurocents.
        /// </summary>
        [Required]
        [JsonProperty("value")]
        public int Value { get; set; }

        /// <summary>
        /// One of "document", "package" or "pallet"
        /// </summary>
        [Required]
        [JsonProperty("kind")]
        public string Kind { get; set; }
        /// <summary>
        /// Length of the whole package, in centimeters
        /// </summary>
        [Required]
        [JsonProperty("length")]
        public int Length { get; set; }
        /// <summary>
        /// Width of the whole package, in centimeters
        /// </summary>
        [Required]
        [JsonProperty("width")]
        public int Width { get; set; }
        /// <summary>
        /// Height of the whole package, in centimeters
        /// </summary>
        [Required]
        [JsonProperty("height")]
        public int Height { get; set; }
        /// <summary>
        /// Weight of the whole package in grams
        /// </summary>
        [Required]
        [JsonProperty("weight")]
        public int Weight { get; set; }
        [Required]
        [JsonProperty("delivery_address")]
        public Models.Address DeliveryAddress { get; set; }

        [Required]
        [JsonProperty("pickup_address")]
        public Models.Address PickupAddress { get; set; }

        /// <summary>
        /// Personal message for the customer that will be included in the email sent to them
        /// </summary>
        [JsonProperty("personal_message")]
        public string PersonalMessage { get; set; }

        /// <summary>
        /// Picture of the shipment
        /// </summary>
        [JsonProperty("picture")]
        public byte[] Picture { get; set; }

        /// <summary>
        /// Free form customer reference for the web shop
        /// </summary>
        [JsonProperty("customer_reference")]
        public string CustomerReference { get; set; }

        /// <summary>
        /// Indicates if this is a return shipment.Defaults to false.
        /// </summary>
        [JsonProperty("is_return")]
        public bool IsReturn { get; set; }

        /// <summary>
        /// Indicates if this is a shipment with a parcel shop drop off.Defaults to false.
        /// </summary>
        [JsonProperty("drop_off")]
        public bool DropOff { get; set; }

        /// <summary>
        /// The preferred service level label as specified by the filter configuration. Check the available filters here
        /// </summary>
        /// <see cref="https://wearewuunder.com/filters-transport-services/"/>
        [Required]
        [JsonProperty("preferred_service_level")]
        public string PreferredServiceLevel { get; set; }

        /// <summary>
        /// Id of the parcelshop where the shipment needs to be sent to
        /// </summary>
        [JsonProperty("parcelshop_id")]
        public string ParcelShopId { get; set; }

        /// <summary>
        /// Number of same labels to book. Should be >= 1 <= 10.
        /// </summary>
        [JsonProperty("number_of_items")]
        public int NumberOfItems { get; set; }

        /// <summary>
        /// Order lines are used for sending information about the content of your package to the customs departments and required for shipping to non-EU countries (Brexit)​
        /// </summary>
        [JsonProperty("order_lines")]
        public List<OrderLine> OrderLines { get; set; } 
    }
}
