using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.Interface.Repository;

namespace Workspace.Poc.Ado.DataAccess.Repository
{
    public class LocationRepo : ILocationRepo
    {
        private readonly SqlConnection _connection;
        public LocationRepo(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Location> GetById(int id)
        {
            Location location = new Location();
            using (SqlCommand cmd = new SqlCommand("UspGetLocationById", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                await _connection.OpenAsync();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        location.Id = reader.GetInt32("Id");
                        location.LocationName = reader.GetString("LocationName");
                    }
                }
            }
            await _connection.CloseAsync();
            return location;
        }
    }
}
