using EmployeeManagement.Shared.Models;
using EmployeeManagement.Server.Repository;

namespace EmployeeManagement.Server.Manager
{
	public class EmployeeManager : IEmployeeManager
	{

		private readonly IEmployeeRepository _employeeRepository;
		public EmployeeManager(IEmployeeRepository employeeRepository) 
		{ 
			_employeeRepository = employeeRepository;
		}

		public async Task<GridParameterModel> GetEmployees(int page, int pageSize, string sortColumn, string sortDirection)
		{
            try
            {
                var result = await _employeeRepository.GetEmployees(page, pageSize, sortColumn, sortDirection);
                return result;
            }
            catch (Exception ex)
            {
                return new GridParameterModel();
            }
        }
        public async Task<Employee> GetEmployeeByID(int ID)
        {
            return await _employeeRepository.GetEmployeeByID(ID);
        }
        public async Task<Employee> CreateEmployee(Employee objEmployee)
		{
			return await _employeeRepository.CreateEmployee(objEmployee);
		}

		public async Task<Employee> EditEmployee(Employee objEmployee)
		{
			return await _employeeRepository.EditEmployee(objEmployee);
		}

		public async Task<bool> DeleteEmployee(int ID)
		{
			return await _employeeRepository.DeleteEmployee(ID);
		}
    }
}
