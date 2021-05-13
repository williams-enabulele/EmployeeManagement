﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Core.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee.Core.Entities.Employee>
    {
        Task<IEnumerable<Employee.Core.Entities.Employee>> GetEmployeeByLastName(string lastname);
    }
}
