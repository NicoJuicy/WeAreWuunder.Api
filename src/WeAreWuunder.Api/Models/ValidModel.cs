using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreWuunder.Api.Models
{
    public class ValidModel<TModel>
    {
        public bool IsValid => Value != null;

        public TModel Value { get; set; }

       
    }

    public class ErrorModel
    {
        [JsonProperty("Errors")]
        public List<ErrorMessage> Errors { get; set; }

        public override string ToString()
        {
            return string.Join("\n", Errors);
        }
    }

    public class ErrorMessage
    {
        public List<string> messages { get; set; }
        public string field { get; set; }

        public override string ToString()
        {
            return $"field {field} has errors: {string.Join(", ", messages)}";
        }
    }
}
