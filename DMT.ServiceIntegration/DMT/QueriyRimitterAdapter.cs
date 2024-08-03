using DMT.Domain.Core;
using DMT.Domain.Core.Helper;
using DMT.Domain.Core.Interface;
using DMT.Domain.DMT;
using DMT.ServiceIntegration.DataContract;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.ServiceIntegration.DMT
{
    public class QueriyRimitterAdapter : IServiceAdapterAsync<QueryRimitterServiceContractRequest, QueryRimitterServiceContractResponse>
    {


        public async Task<QueryRimitterServiceContractResponse> Excute(QueryRimitterServiceContractRequest input)
        {
            var response = new QueryRimitterServiceContractResponse();
            try
            {
                JwtTokenCreationPaySprint jwtTokenCreationPaySprint = new JwtTokenCreationPaySprint();
                var options = new RestClientOptions("https://sit.paysprint.in/service-api/api/v1/service/dmt/remitter/queryremitter");
                var client = new RestClient(options);
                var request = new RestRequest("", Method.Post);
                request.AddHeader("accept", "application/json");
                request.AddHeader("Token", jwtTokenCreationPaySprint.GetToken());

                //request.AddHeader("Token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJQQVlTUFJJTlQiLCJ0aW1lc3RhbXAiOjE2MTAwMjYzMzgsInBhcnRuZXJJZCI6IlBTMDAxIiwicHJvZHVjdCI6IldBTExFVCIsInJlcWlkIjoxNjEwMDI2MzM4fQ.buzD40O8X_41RmJ0PCYbBYx3IBlsmNb9iVmrVH9Ix64");
                request.AddHeader("Authorisedkey", "MzNkYzllOGJmZGVhNWRkZTc1YTgzM2Y5ZDFlY2EyZTQ=");
                request.AddJsonBody(new
                {
                    mobile = input.mobile,
                    bank3_flag = "NO",
                    bank4_flag = "NO",
                    merchantcode = ""
                });



                var apiResponse = await client.PostAsync(request);
                if (apiResponse.IsSuccessful)
                {
                    //Deserialize the response into the response object
                    response = JsonConvert.DeserializeObject<QueryRimitterServiceContractResponse>(apiResponse.Content);

                    //Additional processing based on the response status code
                    if (response.Status)
                    {
                        response.IsSuccess = true;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.ErrorMessage = response.Message;
                    }
                }
                else
                {
                    response.IsSuccess = false;
                    response.ErrorMessage = $"API call failed with status code {apiResponse.StatusCode}";
                }

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as required
                Console.WriteLine($"An error occurred: {ex.Message}");

                // Update the response to indicate an error
                response.ErrorMessage = $"An error occurred: {ex.Message}";

            }

            return response;



        }


    }
}

