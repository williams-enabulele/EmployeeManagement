using Employee.Infrastructure.Data;
using Employee.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee.Core.Entities.Employee>
    {
        protected private EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context) : base(context){
            _context = context;
        }

        public async Task<IEnumerable<Core.Entities.Employee>> GetEmployeeByLastName(string lastname)
        {
            return await _context.Employees.Where(x => x.LastName == lastname).ToListAsync();
        }
    }
}
