using Kanini.Poc.Ado.UspDataAccess.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanini.Poc.Ado.UspDataAccess.Repostiory
{
    public  class UspConnection : IUspConnection
    {
        private readonly IConfiguration _configuration;

        public UspConnection(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
        }
    }
}
