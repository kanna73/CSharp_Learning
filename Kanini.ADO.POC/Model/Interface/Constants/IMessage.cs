namespace Kanini.Poc.Ado.Domain.Interface.Constants
{
    public interface IMessage
    {
        string EmployeeAddedSuccessfully { get; }
        string EmployeeUpdateSuccess { get; }
        string EmployeeDeleteSuccess { get; }
        string ErrorOccurred { get; }
    }
}
