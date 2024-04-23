﻿using ams.application.Employees.GetEmployeeCategories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Employees
{
    [Route("api/employeecategories")]
    [ApiController]
    public class EmployeeCategoriesController : ControllerBase
    {
        ISender _sender;
        public EmployeeCategoriesController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeCategories(CancellationToken cancellationToken = default)
        {
            var categoryQuery = new GetEmployeeCategoryQuery();
            var categories = await _sender.Send(categoryQuery, cancellationToken);
            return Ok(categories);
        }
    }
}
