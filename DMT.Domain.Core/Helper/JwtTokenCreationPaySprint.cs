using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMT.Domain.Core.Helper
{
    public class JwtTokenCreationPaySprint
    {
        public string GetToken()
        {
            try
            {
                string jwtKey = "UFMwMDEyNGQ2NTliODUzYmViM2I1OWRjMDc2YWNhMTE2M2I1NQ==";

                // Create Security key  using private key above:
                // note that latest version of JWT using Microsoft namespace instead of System
                var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));

                // Also note that securityKey length should be >256b
                // so you have to make sure that your private key has a proper length
                var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
                                  (securityKey, "HS256");

                //  Finally create a Token
                var header = new JwtHeader(credentials);

                //Random 6 digit code for 
                Random rnd = new Random();
                int min = 000000;
                int max = 999999;
                int reqId = rnd.Next(min, max);

                //
                DateTime expiry = DateTime.UtcNow.AddMinutes(5);
                int timeStamp = (int)(expiry - new DateTime(1970, 1, 1)).TotalSeconds;

                //Some PayLoad that contain information about the  customer   DateTimeOffset.Now.ToUnixTimeMilliseconds()
                var payload = new JwtPayload
            {

                {"timestamp", timeStamp},
                {"partnerId","PS001" },
                { "reqid",reqId},
            };

                //
                var secToken = new JwtSecurityToken(header, payload);
                var handler = new JwtSecurityTokenHandler();

                // Token to String so you can use it in your client
                var tokenString = handler.WriteToken(secToken);

                return tokenString;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
