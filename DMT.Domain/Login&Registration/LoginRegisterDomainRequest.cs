﻿namespace DMTAPI.API.Controllers.Login_Registration
{
    public class LoginRegisterDomainRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string IS_Active { get; set; }
        public string City { get; set; }
        public string User_Type { get; set; }  
    }
}
