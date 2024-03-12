using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Poc.Ado.Service.Exceptions
{
    public class Error
    {
        public int ID { get; set; }
        public string Message { get; set; }

        public Error(int ID, string Message)
        {
            this.ID = ID;
            this.Message = Message;
        }
    }
}
