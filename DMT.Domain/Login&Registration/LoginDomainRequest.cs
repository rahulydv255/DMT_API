﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Domain.Login_Registration
{
    public class LoginDomainRequest
    {
        public string UserEmail { get; set; }

        public string Password { get; set; }
    }
}
