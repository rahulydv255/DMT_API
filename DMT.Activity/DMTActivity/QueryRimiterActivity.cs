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
    public class QueryRimiterActivity : IActivity<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse>
    {
        private readonly IServiceAdapterAsync<QueryRimitterServiceContractRequest, QueryRimitterServiceContractResponse> _queriyRimitterAdapter;
        private readonly IDatabaseAdapter<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> _saveRemmiterAdapter;

        public QueryRimiterActivity(IServiceAdapterAsync<QueryRimitterServiceContractRequest, QueryRimitterServiceContractResponse> queriyRimitterAdapter,
                                    IDatabaseAdapter<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> saveRemmiterAdapter)
        {
            _queriyRimitterAdapter = queriyRimitterAdapter;
            _saveRemmiterAdapter = saveRemmiterAdapter;
        }




        public QueryRemiterDomainRespoonse Excute(QueryRemiterDomainRequest input)
        {
            var response = new QueryRemiterDomainRespoonse();
            var serviceInput = new QueryRimitterServiceContractRequest();
            serviceInput.mobile=input.mobile;
            serviceInput.bankFlag=input.bankFlag;
            
            var Serviceresponse = _queriyRimitterAdapter.Excute(serviceInput);

            if (Serviceresponse != null)
            {
                var resp = _saveRemmiterAdapter.Execute(input);
            }
            return response;



            //}
        }
    }
}
