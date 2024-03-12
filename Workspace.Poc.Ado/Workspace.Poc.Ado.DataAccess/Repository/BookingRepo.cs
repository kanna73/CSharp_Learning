using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using Workspace.Poc.Ado.Domain.Entity;
using Workspace.Poc.Ado.Domain.Interface.Repository;
using Workspace.Poc.Ado.Domain.ViewModel;

namespace Workspace.Poc.Ado.DataAccess.Repository
{
    public class BookingRepo : IBookingRepo
    {
        private readonly SqlConnection _connection;
        public BookingRepo(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddMeeting(BookMeeting bookMeeting)
        {
            using (SqlCommand cmd = new SqlCommand("UspAddMeeting", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@meetingId", bookMeeting.MeetingId);
                cmd.Parameters.AddWithValue("@meetingTitle", bookMeeting.MeetingTitle);
                cmd.Parameters.AddWithValue("@startTime", bookMeeting.StartTime);
                cmd.Parameters.AddWithValue("@endTime", bookMeeting.EndTime);
                cmd.Parameters.AddWithValue("@bookDate", bookMeeting.BookDate);
                cmd.Parameters.AddWithValue("@userId", bookMeeting.UserId);
                await _connection.OpenAsync();
                int row = await cmd.ExecuteNonQueryAsync();
                await _connection.CloseAsync();
                return row;
            }
        }
        public async Task<bool> ValidateMeeting(BookMeeting bookMeeting)
        {
            using (SqlCommand cmd = new SqlCommand("UspCheckMeetingOverlap", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InputStartTime", bookMeeting.StartTime);
                cmd.Parameters.AddWithValue("@InputEndTime", bookMeeting.EndTime);
                cmd.Parameters.AddWithValue("@InputMeetingID", bookMeeting.MeetingId);
                cmd.Parameters.AddWithValue("@InputDate", bookMeeting.BookDate);
                cmd.Parameters.Add("@RecordExist", SqlDbType.Bit).Direction = ParameterDirection.Output;
                await _connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                bool valid = (bool)cmd.Parameters["@RecordExist"].Value;
                await _connection.CloseAsync();
                return valid;
            }
        }

        public async Task<IEnumerable<TodaysMeetingResponse>> GetTodayMeeting()
        {
            List<TodaysMeetingResponse> todayMeetings = new List<TodaysMeetingResponse>();
            using (SqlCommand cmd = new SqlCommand("USPGetTodayMeeting", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                await _connection.OpenAsync();
                using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        TodaysMeetingResponse todayMeeting = new TodaysMeetingResponse();
                        todayMeeting.MeetingTitle = reader.GetString("MeetingTitle");
                        todayMeeting.RoomName = reader.GetString("RoomName");
                        todayMeeting.StartTime = (TimeSpan?)reader["StartTime"];
                        todayMeeting.EndTime = (TimeSpan?)reader["EndTime"];
                        todayMeeting.BookDate = reader.GetDateTime("BookDate");
                        todayMeeting.LocationName = reader.GetString("LocationName");
                        todayMeeting.EmpName = reader.GetString("EmpName");
                        todayMeeting.Imagepath = reader.GetString("Imagepath");
                        todayMeetings.Add(todayMeeting);
                    }
                }
            }
            await _connection.CloseAsync();
            return todayMeetings;
        }
    }
}
