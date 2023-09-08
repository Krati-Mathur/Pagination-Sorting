using EmployeeManagement.Server.DBContext;
using EmployeeManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;
using BlazorPagination;
using AutoMapper;

namespace EmployeeManagement.Server.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly IMapper _mapper;
        public EmployeeRepository(EmployeeContext employeecontext, IMapper mapper)
        {
            _employeeContext = employeecontext ??
                throw new ArgumentNullException(nameof(employeecontext));
            _mapper = mapper;
        }
        public async Task<GridParameterModel> GetEmployees(int page, int pageSize, string sortColumn, string sortDirection)
        {
            try
            {
                var employee = await _employeeContext.Employees.AsQueryable().OrderBy(sortColumn, sortDirection)
                .ToPagedResultAsync(page, pageSize);
                var temp = new GridParameterModel()
                {
                    CurrentPage = employee.CurrentPage,
                    FirstRowOnPage = employee.FirstRowOnPage,
                    LastRowOnPage = employee.LastRowOnPage,
                    PageCount = employee.PageCount,
                    PageSize = employee.PageSize,
                    RowCount = employee.RowCount,
                    Results = _mapper.Map<List<Employee>>(employee.Results),
                };
                return temp;
            }
            catch (Exception ex)
            {
                return new GridParameterModel();
            }
        }
        public async Task<Employee> GetEmployeeByID(int ID)
        {
            var empresult = await _employeeContext.Employees.FindAsync(ID);
            return empresult;
        }
        public async Task<Employee> CreateEmployee(Employee objEmployee)
        {
            _employeeContext.Employees.Add(objEmployee);
            await _employeeContext.SaveChangesAsync();
            return objEmployee;
        }
        public async Task<Employee> EditEmployee(Employee objEmployee)
        {
            _employeeContext.Entry(objEmployee).State = EntityState.Modified;
            await _employeeContext.SaveChangesAsync();
            return objEmployee;
        }
        public async Task<bool> DeleteEmployee(int ID)
        {
            int isEmployeeDeleted;
            var employee = await _employeeContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == ID);
            if (employee != null)
            {
                _employeeContext.Employees.Remove(employee);
                isEmployeeDeleted = await _employeeContext.SaveChangesAsync();
                return (isEmployeeDeleted>0);
            }
            return false;
        }
    }
}
