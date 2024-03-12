using Microsoft.Data.SqlClient;

namespace DataLayer.Interface
{
    public interface IConnection
    {
        SqlConnection GetConnection();
    }
}
