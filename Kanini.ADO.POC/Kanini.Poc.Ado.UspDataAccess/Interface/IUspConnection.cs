using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanini.Poc.Ado.UspDataAccess.Interface
{
    public interface IUspConnection
    {
        SqlConnection GetConnection();

    }
}
