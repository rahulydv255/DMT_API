using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Contracts.Login_Registration
{
    public class LoginContractResponse
    {
       
        public bool IsValid { get; set; }

        public string Message { get; set; }
    }
}
