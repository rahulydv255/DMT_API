using AutoMapper;
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
        public readonly IActivityAsync<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> _queryRimiterActivity;
        private readonly IMapper _mapper;
        public DMTController(IActivityAsync<QueryRemiterDomainRequest, QueryRemiterDomainRespoonse> queryRimiterActivity,
              IMapper mapper)
        {
            _queryRimiterActivity = queryRimiterActivity;
            _mapper = mapper;

        }


        [HttpPost]
        [Route("api/QueryRemiter")]
        public async Task<QueryRemiterContractResponse> QueryRemitter(QueryRemiterContractRequest queryRemiterRequest)
        { 
            var response =new QueryRemiterContractResponse();
            var queryRemiterDomainRequest=new QueryRemiterDomainRequest();
            queryRemiterDomainRequest.mobile=queryRemiterRequest.mobile;
            queryRemiterDomainRequest.bankFlag=queryRemiterRequest.bankFlag;
            Debug.WriteLine($"Massage = {_queryRimiterActivity}");
            var queryRemiterDomainRespoonse =  await _queryRimiterActivity.Excute(queryRemiterDomainRequest);
            response = _mapper.Map<QueryRemiterContractResponse>(queryRemiterDomainRespoonse);

            return response;
        }
    }
}
