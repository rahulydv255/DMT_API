using DMT.Domain.Core.Interface;
using DMT.Domain.Login_Registration;
using DMTAPI.API.Controllers.Login_Registration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMt.DataAccess.LoginRegister
{
    public class LoginAdapter : IDatabaseAdapter<LoginDomainRequest, LoginDomainResponse>
    {
        private readonly string _connectionString;

        public LoginAdapter(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginDomainResponse Execute(LoginDomainRequest input)
        {
            var response = new LoginDomainResponse();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open(); // Open the connection

                    using (SqlCommand command = new SqlCommand("SP_LOGIN", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.Add(new SqlParameter("@email", input.UserEmail));
                        command.Parameters.Add(new SqlParameter("@password", input.Password));
 

                        int rowsAffected = (int)command.ExecuteScalar();

                        // Check if data was inserted successfully
                        if (rowsAffected > 0)
                        {
                           response.Message = "Login successfully.";
                        }
                        else
                        {
                             response.Message = "Login failed.";
                        }

                        // Optionally, retrieve any output from the stored procedure
                        // Example:
                        // loginRegisterDomainResponse.Message = command.Parameters["@outputParameterName"].Value.ToString();
                    }

                    connection.Close(); // Close the connection explicitly or use 'using' block
                }
            }
            catch (Exception ex)
            {
                // Handle exception appropriately
                // Example: log the exception, throw custom exception, etc.
                response.Message = "Error occurred during database operation.";
                // Log the exception: logger.LogError(ex, "Error occurred during database operation.");
            }


            return response;
        }
    }
}
