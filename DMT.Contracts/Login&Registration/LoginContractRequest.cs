using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Contracts.Login_Registration
{
    public class LoginContractRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
