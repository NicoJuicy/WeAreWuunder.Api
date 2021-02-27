using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreWuunder.Api.Models
{
    public class Address
    {
        /// <summary>
        /// ISO-2 country code, for example "NL" or "BE".
        /// </summary>
        [JsonProperty("country")]
        [Required]
        public string Country { get; set; }
        [JsonProperty("family_name")]
        [MaxLength(30)]
        public string FamilyName { get; set; }
        [JsonProperty("given_name")]
        [MaxLength(30)]
        public string Givenname { get; set; }

        /// <summary>
        /// Number including any additions.
        /// </summary>
        [JsonProperty("house_number")]
        [MaxLength(8)]
        [Required]
        public string HouseNumber { get; set; }

        [JsonProperty("locality")]
        [MaxLength(30)]
        [Required]
        public string Locality { get; set; }

        [JsonProperty("zip_code")]
        [MaxLength(9)]
        [Required]
        public string ZipCode { get; set; }

        /// <summary>
        /// Street part of the addresses
        /// </summary>
        [JsonProperty("street_name")]
        [MaxLength(35)]
        [Required]
        public string StreetName { get; set; }

        [JsonProperty("address2")]
        [MaxLength(35)]
        public string Address2 { get; set; }
        /// <summary>
        /// When included this addresses will be regarded a business address, otherwise a private address
        /// </summary>
        public string Business { get; set; }
        [JsonProperty("email_address")]
        //[MaxLength(40)] ( recommended)
        public string EmailAddress { get; set; }

        [JsonProperty("phone_number")]
        public string Phone { get; set; }

        [JsonProperty("chamber_of_commerce_number")]
        public string ChamberOfCommerceNumber { get; set; }

        /// <summary>
        /// Sender EORI number (only for pickup_address) and required for shipping to non-EU countries (Brexit)
        /// </summary>
        [JsonProperty("eori_number")]
        public string EoriNumber { get; set; }

        /// <summary>
        /// VAT number including country code required for shipping to non-EU countries (Brexit)
        /// </summary>
        [JsonProperty("vat")]
        public string VatNumber { get; set; }

    }
}
