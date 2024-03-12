using Kanini.Poc.Ado.Domain.Interface.Constants;

namespace Kanini.Poc.Ado.Constants.Constants
{
    public class Messages : IMessage
    {
        public string EmployeeAddedSuccessfully => "Employee added successfully";
        public string EmployeeUpdateSuccess => "Updated successfully";
        public string EmployeeDeleteSuccess => "Deleted successfully";
        public string ErrorOccurred => "Error Occurred";
    }
}
