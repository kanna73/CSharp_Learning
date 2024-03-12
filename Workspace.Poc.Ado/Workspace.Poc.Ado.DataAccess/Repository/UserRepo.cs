using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.Interface.Repository;

namespace Workspace.Poc.Ado.DataAccess.Repository
{
    public class UserRepo : IUserRepo 
    {
        private readonly SqlConnection _connection;
        public UserRepo(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            List<User> users = new List<User>();    
            using (SqlCommand cmd = new SqlCommand("select * from Users",_connection))
            {
                await _connection.OpenAsync();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        User user = new User();
                        user.Id = reader.GetInt32("Id");
                        user.EmpName=reader.GetString("EmpName");
                        user.EmpNo = reader.GetString("EmpNo");
                        user.Email = reader.GetString("Email");
                        users.Add(user);
                    }
                }
            }
            await _connection.CloseAsync();

            return users;
        }

        public async Task<int> AddUser(User user)
        {
            using(SqlCommand cmd = new SqlCommand("UspAddUser", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpName", user.EmpName);
                cmd.Parameters.AddWithValue("@EmpNo",user.EmpNo);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Hashkey", user.Hashkey);
                cmd.Parameters.AddWithValue("@LocationID", user.LocationId);
                await _connection.OpenAsync();
                int row = await cmd.ExecuteNonQueryAsync();
                await _connection.CloseAsync();
                return row;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            User user = new User();
            using (SqlCommand cmd = new SqlCommand("UspGetByEmail",_connection))
            {
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                await _connection.OpenAsync();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        user.Id = reader.GetInt32("Id");
                        user.EmpName = reader.GetString("EmpName");
                        user.EmpNo = reader.GetString("EmpNo");
                        user.Email = reader.GetString("Email");
                        user.Password = (byte[])reader["Password"];
                        user.Hashkey = (byte[])reader["Hashkey"];
                        user.LocationId = reader.GetInt32("LocationID");

                    }
                }
            }
            await _connection.CloseAsync();

            return user;

        }
    }
}
