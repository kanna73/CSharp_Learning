using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.Interface.Repository;

namespace Workspace.Poc.Ado.DataAccess.Repository
{
    public class RoomRepo : IRoomRepo
    {
        private readonly SqlConnection _connection;
        public RoomRepo(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Room>> GetMeetingRooms(int locationId)
        {
            List<Room> rooms = new List<Room>();
            using(SqlCommand cmd =new SqlCommand("UspGetRoomByLocationId",_connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@locationId", locationId);
                await _connection.OpenAsync();
                using(SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        Room room = new Room();
                        room.Id = reader.GetInt32("Id");
                        room.RoomName = reader.GetString("RoomName");
                        room.LocationId = reader.GetInt32("LocationId");
                        room.Imagepath = reader.GetString("Imagepath");
                        room.Capacity = reader.GetInt32("Capacity");
                        rooms.Add(room);
                    }
                }
            }
            await _connection.CloseAsync();
            return rooms;
        }

    }
}
