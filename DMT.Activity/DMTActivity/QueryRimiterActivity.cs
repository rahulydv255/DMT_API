using AutoMapper;
using DMT.Domain.Core.Interface;
using DMT.Domain.DMT;
using DMT.ServiceIntegration.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Activity.DMTActivity
{
    public class QueryRimiterActivity : IActivityAsync<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse>
    {
        private readonly IServiceAdapterAsync<QueryRimitterServiceContractRequest, QueryRimitterServiceContractResponse> _queriyRimitterAdapter;
        private readonly IDatabaseAdapter<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> _saveRemmiterAdapter;
        private readonly IMapper _mapper;

        public QueryRimiterActivity(IServiceAdapterAsync<QueryRimitterServiceContractRequest, QueryRimitterServiceContractResponse> queriyRimitterAdapter,
                                    IDatabaseAdapter<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> saveRemmiterAdapter,
                                    IMapper mapper)
        {
            _queriyRimitterAdapter = queriyRimitterAdapter;
            _saveRemmiterAdapter = saveRemmiterAdapter;
            _mapper = mapper;
        }

        public async Task<QueryRemiterDomainRespoonse> Excute(QueryRemiterDomainRequest input)
        {
            var response = new QueryRemiterDomainRespoonse();
            var serviceInput = new QueryRimitterServiceContractRequest();
            var serviceResponse = new QueryRimitterServiceContractResponse();
            serviceInput.mobile = input.mobile;
            serviceInput.bankFlag = input.bankFlag;

            serviceResponse = await _queriyRimitterAdapter.Excute(serviceInput);
            //serviceResponse = new QueryRimitterServiceContractResponse { name = "Rahul" };
             response = _mapper.Map<QueryRemiterDomainRespoonse>(serviceResponse);
            //if (Serviceresponse != null)
            //{
            //    var resp = _saveRemmiterAdapter.Execute(input);
            //}
            return response;

        }
    }
}
