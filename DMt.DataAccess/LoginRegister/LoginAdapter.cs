using DMT.Domain.Core.Interface;
using DMT.Domain.Login_Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMt.DataAccess.LoginRegister
{
    public class LoginAdapter : IDatabaseAdapter<LoginDomainRequest, LoginDomainResponse>
    {
        public LoginDomainResponse Execute(LoginDomainRequest input)
        {
            LoginDomainResponse response = new LoginDomainResponse();  
            



            return response;
        }
    }
}
