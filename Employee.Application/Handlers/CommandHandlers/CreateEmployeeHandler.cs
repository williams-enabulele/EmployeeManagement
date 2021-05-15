using Employee.Application.Commands;
using Employee.Application.Mappers;
using Employee.Application.Responses;
using Employee.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Employee.Application.Handlers
{


    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = EmployeeMapper.Mapper.Map<Employee.Core.Entities.Employee>(request);
            if (employeeEntity is null)
            {
                throw new ApplicationException("Mapper Has Issues");
            }

            var newEmployee = await _employeeRepository.AddAsync(employeeEntity);
            var employeeresponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);
            return employeeresponse;
        }
    }
}