using DMT.Domain.Core;
using DMT.Domain.Core.Helper;
using DMT.Domain.Core.Interface;
using DMT.Domain.DMT;
using DMT.ServiceIntegration.DataContract;
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
                request.AddHeader("accept", jwtTokenCreationPaySprint.GetToken());

                //request.AddHeader("Token", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJQQVlTUFJJTlQiLCJ0aW1lc3RhbXAiOjE2MTAwMjYzMzgsInBhcnRuZXJJZCI6IlBTMDAxIiwicHJvZHVjdCI6IldBTExFVCIsInJlcWlkIjoxNjEwMDI2MzM4fQ.buzD40O8X_41RmJ0PCYbBYx3IBlsmNb9iVmrVH9Ix64");
                request.AddHeader("Authorisedkey", "MzNkYzllOGJmZGVhNWRkZTc1YTgzM2Y5ZDFlY2EyZTQ=");
                request.AddJsonBody(new
                {
                    mobile = input.mobile,
                    bank3_flag = input.bankFlag
                });

                var apiResponse = await client.ExecuteAsync<QueryRimitterServiceContractResponse>(request);



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

