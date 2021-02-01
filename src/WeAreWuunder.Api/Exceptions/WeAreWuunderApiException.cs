using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreWuunder.Api.Models;

namespace WeAreWuunder.Api.Exceptions
{
    public class WeAreWuunderApiException : Exception
    {
        public WeAreWuunderApiException(string message):base(message)
        {

        }
    }
}
