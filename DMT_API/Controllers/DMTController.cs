using DMT.Contracts.DMT;
using DMT.Domain.Core.Interface;
using DMT.Domain.DMT;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web.Http;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


namespace DMTAPI.API.Controllers
{
    [ApiController]
    public class DMTController : ControllerBase
    {
        public readonly IActivity<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> _queryRimiterActivity;
      
        public DMTController(IActivity<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> queryRimiterActivity)
        {
            _queryRimiterActivity = queryRimiterActivity;
        
        }

        [HttpPost]
        [Route("api/QueryRemiter")]
        public QueryRemiterContractResponse QueryRemitter(QueryRemiterContractRequest queryRemiterRequest)
        { 
            var response =new QueryRemiterContractResponse();
            var queryRemiterDomainRequest=new QueryRemiterDomainRequest();
            queryRemiterDomainRequest.mobile=queryRemiterRequest.mobile;
            queryRemiterDomainRequest.bankFlag=queryRemiterRequest.bankFlag;
            Debug.WriteLine($"Massage = {_queryRimiterActivity}");
            var queryRemiterDomainRespoonse =  _queryRimiterActivity.Excute(queryRemiterDomainRequest);
            return response;
        }
    }
}
