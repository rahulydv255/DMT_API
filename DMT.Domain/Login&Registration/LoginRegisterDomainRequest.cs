namespace DMTAPI.API.Controllers.Login_Registration
{
    public class LoginRegisterDomainRequest
    {
        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string password { get; set; }
    }
}
