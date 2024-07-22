using DMT.Domain.Core.Interface;
using DMTAPI.API.Controllers.Login_Registration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DMt.DataAccess.LoginRegister
{
    public class LoginRegisterAdapter : IDatabaseAdapter<LoginRegisterDomainRequest, LoginRegisterDomainResponse>
    {
        private readonly string _connectionString;

        public LoginRegisterAdapter(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginRegisterDomainResponse Execute(LoginRegisterDomainRequest input)
        {
            var loginRegisterDomainResponse = new LoginRegisterDomainResponse();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open(); // Open the connection

                    using (SqlCommand command = new SqlCommand("SP_TREGISTER", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.Add(new SqlParameter("@name", input.Name));
                        command.Parameters.Add(new SqlParameter("@UserEmail", input.Email));
                        command.Parameters.Add(new SqlParameter("@password", input.password));
                        command.Parameters.Add(new SqlParameter("@Contact_Num", input.PhoneNo));
                        command.Parameters.Add(new SqlParameter("@is_active", input.IS_Active));
                        command.Parameters.Add(new SqlParameter("@user_type", input.User_Type));


                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if data was inserted successfully
                        if (rowsAffected > 0)
                        {
                            loginRegisterDomainResponse.Message = "Data inserted successfully.";
                        }
                        else
                        {
                            loginRegisterDomainResponse.Message = "Data insertion failed.";
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
                loginRegisterDomainResponse.Message = "Error occurred during database operation.";
                // Log the exception: logger.LogError(ex, "Error occurred during database operation.");
            }

            return loginRegisterDomainResponse;
        }
    }
}
