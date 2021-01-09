using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreWuunder.Api.Models
{
    public class OrderLine
    {
        /// <summary>
        /// The Harmonization Code for this good and required for shipping to non-EU countries(Brexit)​
        /// </summary>
        [JsonProperty("hs_code")]
        public int HsCode { get; set; }

        /// <summary>
        /// ISO-2 country code, for example “NL” or “BE” and required for shipping to non-EU countries (Brexit)​
        /// </summary>
        [JsonProperty("country_of_origin")]
        public string CountryOfOrigin { get; set; }

        /// <summary>
        /// Quantity of the goods and required for shipping to non-EU countries (Brexit
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Description of the goods for this order line. For instance "machine parts" and required for shipping to non-EU countries (Brexit)
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Value in Euro’s of the goods and required for shipping to non-EU countries(Brexit)
        /// </summary>
        [JsonProperty("value")]
        public decimal Value { get; set; }

        /// <summary>
        /// Weight in grams of the good and required for shipping to non-EU countries(Brexit)​
        /// </summary>
        [JsonProperty("weight")]
        public int Weight { get; set; }

        /// <summary>
        /// DSKU of the good​
        /// </summary>
        [JsonProperty("sku")]
        public string SKU { get; set; }

        /// <summary>
        /// EAN of the good
        /// </summary>
        [JsonProperty("ean")]
        public string EAN { get; set; }
    }
}
