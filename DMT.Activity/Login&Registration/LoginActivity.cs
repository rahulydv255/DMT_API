using DMT.Domain.Core.Interface;
using DMT.Domain.Login_Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace DMT.Activity.Login_Registration
{
    public class LoginActivity : IActivity<LoginDomainRequest, LoginDomainResponse>

    {
        private readonly IDatabaseAdapter<LoginDomainRequest, LoginDomainResponse> _loginAdapter;

        public  LoginActivity(IDatabaseAdapter<LoginDomainRequest, LoginDomainResponse> loginAdapter)
        {
            _loginAdapter = loginAdapter;
        }   

        public LoginDomainResponse Excute(LoginDomainRequest input)
        {
            var response = new LoginDomainResponse();

            response= _loginAdapter.Execute(input);
            if (response.IsValid)
            {
                response.Message = "Login successfully";
            }
            else
            {
                response.Message = "Invalid email or password";
            }
            return response;
        }
    }
}
