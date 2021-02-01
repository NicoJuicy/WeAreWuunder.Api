using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeAreWuunder.Api.Exceptions;
using WeAreWuunder.Api.Handlers;
using WeAreWuunder.Api.Models;
using WeAreWuunder.Api.Requests;
using WeAreWuunder.Api.Responses;

namespace WeAreWuunder.Api
{
    public class WeAreWuunderApiClient : Interfaces.IWunderApi
    {
        private Interfaces.IWunderApi apiClient;
        public WeAreWuunderApiClient(Models.Environment env, string apiKey)
        {
            string url = env == Models.Environment.Production ? "https://api.wearewuunder.com/" : "https://api-staging.wearewuunder.com/";

            apiClient = RestService.For<Interfaces.IWunderApi>(new HttpClient(new AuthenticatedHttpClientHandler(apiKey)) { BaseAddress = new Uri(url) });
        }

        private async Task<string> GetToken(string apiKey)
        {
            //// The AcquireTokenAsync call will prompt with a UI if necessary
            //// Or otherwise silently use a refresh token to return
            //// a valid access token	
            //var token = await context.AcquireTokenAsync("http://my.service.uri/app", "clientId", new Uri("callback://complete"));

            //return token;
            return apiKey;
        }


        public async Task<CreateShipmentResponse> CreateShipment(CreateShipmentRequest request)
        {

            var validator = new Validators.CreateShipmentRequestValidator();
            var validateRequest = validator.Validate(request);

            if (!validateRequest.IsValid)
                throw new Exceptions.WeAreWuunderApiException(String.Join("\n", validateRequest.Errors.Select(dl => $"{dl.PropertyName} [{dl.ErrorCode}] - {dl.ErrorMessage}").ToList()));

            CreateShipmentResponse response;
            try
            {
                response = await apiClient.CreateShipment(request);
            }
            catch (ApiException ex)
            {
                if (((int)ex.StatusCode) == 422)
                {
                    var errors = WuunderApiHelpers.FlattenErrors(ex.Content);
                    throw new WeAreWuunderApiException(String.Join("\n",errors));
                }
                if ((int)ex.StatusCode >= 500)
                {
                    throw new WeAreWuunderApiException("Try again later. ");
                }
                throw;
            }
            return response;
        }

        //public async Task<List<CreateShipmentResponse>> GetShipments()
        //{
        //    return await apiClient.GetShipments();
        //}
    }
}
