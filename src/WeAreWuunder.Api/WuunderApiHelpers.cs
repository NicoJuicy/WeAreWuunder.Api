using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreWuunder.Api
{
    public static class WuunderApiHelpers
    {
        public static List<string> FlattenErrors(string errorJson)
        {
            List<string> errors = new List<string>();

            var errorModel = JObject.Parse(errorJson);
            foreach (var error in errorModel["errors"])
            { 
                foreach(var errorMessage in error["messages"])
                {

                    if(!errorMessage.HasValues)
                    {
                        errors.Add($"Field : {error["field"]} has error: {errorMessage}");
                        continue;
                    }

                    if(errorMessage.HasValues)
                    {
                        foreach(JProperty childErrorMessage in errorMessage.Children())
                        {
                            foreach(var childErrorMessageValue in childErrorMessage.Values())
                            {
                                errors.Add($"Field : {error["field"]}/{childErrorMessage.Name} has error: {childErrorMessageValue}");
                                continue;
                            }
                        }
                    }
                }
            }

            return errors;
        }
    }
}
