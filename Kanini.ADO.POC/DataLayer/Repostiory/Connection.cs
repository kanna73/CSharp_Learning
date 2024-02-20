using DataLayer.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repostiory
{
    public  class Connection : IConnection
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=KANINI-LTP-556;Database=Employee;User Id=sa;Password=Kanna@5873;Encrypt=False;TrustServerCertificate=true");
        }
    }
}
