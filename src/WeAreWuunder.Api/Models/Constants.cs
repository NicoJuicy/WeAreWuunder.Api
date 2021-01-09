using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreWuunder.Api.Models
{
    public static class  Constants
    {
    
        static Constants()
        {
            ShippingServiceLevels = new List<string>();
            AddServiceLevels("asendia",new string[] { "cheapest", "most_efficient", "fastest" });
            AddServiceLevels("brenger", new string[] { "cheapest", "most_efficient", "fastest" });

            AddServiceLevels("dhl_express", new string[] { "cheapest", "most_efficient", "fastest" });
          
          
            AddServiceLevels("rjp", new string[] { "cheapest", "most_efficient", "fastest" });
            AddServiceLevels("rhenus", new string[] { "cheapest", "most_efficient", "fastest" });
            AddServiceLevels("tnt", new string[] { "cheapest", "most_efficient", "fastest" });

            AddServiceLevels("van_spreuvel_transport", new string[] { "cheapest", "most_efficient", "fastest" });

            //With special service levels
            AddServiceLevels("dpd", new string[] { "cheapest", "most_efficient", "fastest","dpd_express_10_hour","dpd_express_12_hour","dpd_guaranteed_18_hour" });

            //
            AddServiceLevels("dhl_parcel", new string[] { "cheapest", "most_efficient", "fastest","dhl_for_you_signature_on_delivery","dhl_europlus_benelux_expresser_11_hour" });

            //
            AddServiceLevels("ups", new string[] { "cheapest", "most_efficient", "fastest", "ups_standard","ups_saver","ups_express","ups_express_plus","ups_standard_insurance","ups_saver_insurance","ups_express_insurance",
                "ups_standard_cod","ups_saver_cod","ups_express_cod","ups_standard_cod_insurance","ups_saver_cod_insurance","ups_express_cod_insurance","ups_express_plus","ups_express_plus_insurance","ups_express_plus_cod","ups_express_plus_cod_insurance" });

            AddServiceLevels("dpd_be", new string[] { "cheapest", "most_efficient", "fastest","dpd_be_express_10","dpd_be_express_12","dpd_be_express_18" });

            AddServiceLevels("dhl_be_parcel", new string[] { "cheapest", "most_efficient", "fastest","dhl_be_parcel_signature on delivery","dhl_be_parcel_expresser" });

            AddServiceLevels("post_nl", new string[] { "cheapest", "most_efficient", "fastest", "postnl_gegarandeerd_10_uur", "postnl_gegarandeerd_12_uur","postnl_gegarandeerd_17_uur","postnl_handtekening_voor_ontvangst","postnl_verhoogde_aansprakelijkheid_alleen_huisadres_incl_handtekening" });

            AddServiceLevels("gls", new string[] { "cheapest", "most_efficient", "fastest","gls_express_09","gls_express_12","gls_express_17" });


        }

        private static void AddServiceLevels(string shipper, string[] serviceLevels )
        {
            foreach(var serviceLevel in serviceLevels)
            {
                ShippingServiceLevels.Add($"{shipper}:{serviceLevel}");
            }
        }

      
        /// <summary>
        /// Please check https://wearewuunder.com/handleiding/automatisch-de-juiste-service-en-vervoerder-kiezen/
        /// </summary>
        public static List<string> ShippingServiceLevels;

        public static string[] Kinds = new string[] { "document", "package", "pallet" };

    }
}
