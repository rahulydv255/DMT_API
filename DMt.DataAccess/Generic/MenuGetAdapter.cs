using DMT.Domain.Core.Interface;
using DMT.Domain.Generic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMt.DataAccess.Generic
{
    public class MenuGetAdapter : IDatabaseAdapter<MenuDomainRequest, MenuDomainResponse>
    {
        private readonly string _connectionString;

        public MenuGetAdapter(string connectionString)
        {
            _connectionString = connectionString;
        }
        public MenuDomainResponse Execute(MenuDomainRequest input)
        {

            var response = new MenuDomainResponse();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Get_MenuList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Item item = new Item
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Title = reader["Title"].ToString(),
                                Url = reader["Url"].ToString(),
                                ParentId = reader["ParentId"] != DBNull.Value ? (int?)Convert.ToInt32(reader["ParentId"]) : null
                            };
                            response.MenuItem.Add(item);
                        }
                    }
                }
            }
            return response;

        }
    }
}
