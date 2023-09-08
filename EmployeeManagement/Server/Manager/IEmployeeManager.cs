using EmployeeManagement.Shared.Models;

namespace EmployeeManagement.Server.Repository
{
    public interface IEmployeeManager
    {
        Task<GridParameterModel> GetEmployees(int page, int pageSize, string sortColumn, string sortDirection);
        Task<Employee> GetEmployeeByID(int ID);
        Task<Employee> CreateEmployee(Employee objEmployee);
        Task<Employee> EditEmployee(Employee objEmployee);
        Task<bool> DeleteEmployee(int ID);
    }
}
