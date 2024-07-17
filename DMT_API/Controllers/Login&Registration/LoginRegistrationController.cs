using DMT.Activity.DMTActivity;
using DMT.Contracts.DMT;
using DMT.Contracts.Login_Registration;
using DMT.Domain.Core.Interface;
using DMT.Domain.DMT;
using DMT.Domain.Login_Registration;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DMTAPI.API.Controllers.Login_Registration
{
    [ApiController]
    public class LoginRegistrationController : ControllerBase
    {
        public readonly IActivity<LoginRegisterDomainRequest, LoginRegisterDomainResponse> _loginRegisterActivity;
        public readonly IActivity<LoginDomainRequest, LoginDomainResponse> _loginActivity;

        public LoginRegistrationController(IActivity<LoginRegisterDomainRequest, LoginRegisterDomainResponse> loginRegisterActivity,
                                            IActivity<LoginDomainRequest, LoginDomainResponse> loginActivity)
        {

            _loginRegisterActivity = loginRegisterActivity;
            _loginActivity = loginActivity;

        }

        [HttpPost]
        [Route("api/Register")]
        public LoginRegisterContractResponse Register(LoginRegisterContractRequest loginRegisterRequest)
        {
            var response = new LoginRegisterContractResponse();
            var loginRegisterDomainRequest = new LoginRegisterDomainRequest();
            var loginRegisterDomainResponse = new LoginRegisterDomainResponse();
            loginRegisterDomainRequest.Name = loginRegisterRequest.Name;
            loginRegisterDomainRequest.PhoneNo = loginRegisterRequest.PhoneNo;
            loginRegisterDomainRequest.Address = loginRegisterRequest.Address;
            loginRegisterDomainRequest.City = loginRegisterRequest.City;
            loginRegisterDomainRequest.password= loginRegisterRequest.Password;
            loginRegisterDomainResponse = _loginRegisterActivity.Excute(loginRegisterDomainRequest);
            response.Message = loginRegisterDomainResponse.Message;
            return response;
        }

        [HttpPost]
        [Route("api/Login")]
        public LoginContractResponse Login(LoginContractRequest loginRequest)
        {
            var response = new LoginContractResponse();
            var loginDomainRequest = new LoginDomainRequest();
            var loginDomainResponse = new LoginDomainResponse();
            //loginDomainRequest.UserEmail = loginRequest.Email;
            //loginDomainRequest.Password = loginRequest.Password;
            loginDomainResponse = _loginActivity.Excute(loginDomainRequest);
            response.IsValid = loginDomainResponse.IsValid;
            response.Message = loginDomainResponse.Message;
            return response;
        }







    }
}
