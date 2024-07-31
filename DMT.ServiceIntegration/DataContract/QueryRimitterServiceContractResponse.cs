using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.ServiceIntegration.DataContract
{
    public class QueryRimitterServiceContractResponse
    {

        //public string name { get; set; }
        public bool Status { get; set; }
        public int ResponseCode { get; set; }
        public string? Message { get; set; }
        public Data? data { get; set; }
        public bool IsSuccess { get; set; } = true; // Default to true
        public string? ErrorMessage { get; set; }
    }

    public class Data
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

