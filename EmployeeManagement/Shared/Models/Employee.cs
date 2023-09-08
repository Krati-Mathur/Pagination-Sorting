using System;
using System.Collections.Generic;

namespace EmployeeManagement.Shared.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }       

    public string? EmailId { get; set; }

    public DateTime? Doj { get; set; }

	public int DepartmentId { get; set; }
}
