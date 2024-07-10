using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.ServiceIntegration.DataContract
{
    public class QueryRimitterServiceContractResponse
    {
        public bool Status { get; set; }
        public int ResponseCode { get; set; }
        public string? Message { get; set; }
        public RemitterData? Data { get; set; }
        public bool IsSuccess { get; set; } = true; // Default to true
        public string? ErrorMessage { get; set; }
    }

    public class RemitterData
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Mobile { get; set; }
        public string? Status { get; set; }
        public int Bank3Limit { get; set; }
        public int Bank2Limit { get; set; }
        public int Bank1Limit { get; set; }
    }


}
