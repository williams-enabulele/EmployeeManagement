﻿using Employee.Application.Commands;
using Employee.Application.Queries;
using Employee.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;

        }
        // GET: EmployeeController
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public  async Task<List<Employee.Core.Entities.Employee>>  Get()
        {
            return await _mediator.Send(new GetAllEmployeeQuery());
        }

       [HttpPost]
       [ProducesResponseType(StatusCodes.Status200OK)]
       public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}
