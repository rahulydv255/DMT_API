using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.ServiceIntegration.DataContract
{
    public class QueryRimitterServiceContractRequest
    {
        public string? mobile { get; set; }
        public string? bankFlag { get; set; } = "NO";

    }
}
