using DMT.Domain.Core.Interface;
using DMT.Domain.DMT;
using DMT.ServiceIntegration.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMt.DataAccess
{
    public class SaveRemmiterAdapter : IDatabaseAdapter<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> 
    {



        public QueryRemiterDomainRespoonse Execute(QueryRemiterDomainRequest input)
        {

            var response = new QueryRemiterDomainRespoonse();
            return response;
        }
    }
}
