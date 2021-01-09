using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeAreWuunder.Api.Handlers
{
    class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        //private readonly Func<Task<string>> getToken;

        //public AuthenticatedHttpClientHandler(Func<Task<string>> getToken)
        //{
        //    if (getToken == null) throw new ArgumentNullException(nameof(getToken));
        //    this.getToken = getToken;
        //}

        private readonly string m_apiKey;
        public AuthenticatedHttpClientHandler(string apiKey)
        {
            m_apiKey = apiKey;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                //var token = await getToken().ConfigureAwait(false);
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, m_apiKey);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
