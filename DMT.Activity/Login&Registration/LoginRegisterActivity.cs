using DMt.DataAccess.LoginRegister;
using DMT.Domain.Core.Interface;
using DMT.Domain.DMT;

namespace DMTAPI.API.Controllers.Login_Registration
{
    public class LoginRegisterActivity : IActivity<LoginRegisterDomainRequest, LoginRegisterDomainResponse>
    {

        private readonly IDatabaseAdapter<LoginRegisterDomainRequest, LoginRegisterDomainResponse> _loginRegisterAdapter;
        public LoginRegisterActivity(IDatabaseAdapter<LoginRegisterDomainRequest, LoginRegisterDomainResponse> loginRegisterAdapter)
        {
            _loginRegisterAdapter = loginRegisterAdapter;
        }


        public LoginRegisterDomainResponse Excute(LoginRegisterDomainRequest input)
        {
            var loginRegisterDomainResponse = new LoginRegisterDomainResponse();

            if (input == null)
            {
                // Handle the null input case appropriately
                loginRegisterDomainResponse.Message = "Invalid data.";
                return loginRegisterDomainResponse;
            }
            else
            {
                var result = _loginRegisterAdapter.Execute(input);
                loginRegisterDomainResponse.Message = result.Message;

            }

            // Add your logic here for processing the input

            return loginRegisterDomainResponse;
        }

    }
}


