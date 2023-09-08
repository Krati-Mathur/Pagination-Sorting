﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Shared.Models
{
    public class GridParameterModel
    {
        public int CurrentPage { get; set; } = 1;
        public int FirstRowOnPage { get; set; }
        public int LastRowOnPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; } = 3;
        public int RowCount { get; set; }
        public List<Employee>? Results { get; set; } = new List<Employee>();
    }
}
