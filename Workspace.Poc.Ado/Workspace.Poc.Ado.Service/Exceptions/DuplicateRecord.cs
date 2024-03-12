using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Poc.Ado.Service.Exceptions
{
    public  class DuplicateRecord :Exception
    {
        string message;

        public DuplicateRecord(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
