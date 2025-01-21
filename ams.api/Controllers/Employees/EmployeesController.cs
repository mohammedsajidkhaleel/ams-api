using ams.api.Controllers.Assets;
using ams.application.Assets.DeleteAsset;
using ams.application.Assets.EditAsset;
using ams.application.Employees.CreateEmployee;
using ams.application.Employees.DeleteEmployee;
using ams.application.Employees.EditEmployee;
using ams.application.Employees.GetEmployee;
using ams.application.Employees.GetEmployees;
using ams.domain.Abstractions;
using FastReport;
using FastReport.Export.PdfSimple;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Employees;

[Authorize]
[ApiController]
[Route("api/employees")]

public class EmployeesController : ControllerBase
{
    private ISender _sender;
    public EmployeesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(EmployeeRequest model,
        CancellationToken cancellationToken)
    {
        var command = new CreateEmployeeCommand(
            model.Code,
            model.Name,
            model.SponsorId,
            model.DepartmentId,
            model.EmployeeCategoryId,
            model.NationalityId,
            model.EmployeePositionId,
            model.Mobile,
            model.Email,
            model.Doj,
            model.ProjectId
            );
        Result<Guid> result = await _sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(CreateEmployee),
            new { id = result.Value }, result.Value);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> EditEmployee([FromRoute] Guid id,
       EmployeeRequest model,
       CancellationToken cancellationToken)
    {
        var command = new EditEmployeeCommand(
            id,
            model.Code,
            model.Name,
            model.SponsorId,
            model.DepartmentId,
            model.EmployeeCategoryId,
            model.NationalityId,
            model.EmployeePositionId,
            model.Mobile,
            model.Email,
            model.Doj,
            model.ProjectId);
        Result<Guid?> result = await _sender.Send(command, cancellationToken);
        return Ok(new { id = result.Value });
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id,
    CancellationToken cancellationToken)
    {
        var command = new DeleteEmployeeCommand(id);
        await _sender.Send(command, cancellationToken);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees([FromQuery] string searchQuery = "",
        [FromQuery] int pageIndex = 0,
        [FromQuery] int pageSize = 50,
        CancellationToken cancellationToken = default)
    {
        var query = new GetEmployeesQuery(pageIndex, pageSize, null, searchQuery);
        var employees = await _sender.Send(query, cancellationToken);
        return Ok(employees);
    }


    [HttpGet("{employeeId:Guid}/report")]
    public async Task<IActionResult> GetEmployeeReport(Guid employeeId,
       CancellationToken cancellationToken = default)
    {
        var query = new GetEmployeeQuery(employeeId);
        var employee = await _sender.Send(query, cancellationToken);
        Report report = new Report();
        report.Load("Reports/EmployeeDetails.frx");
        report.SetParameterValue("Name", employee.Value.Name);
        report.RegisterData(employee.Value.AssignedAccessories, "Accessories");
        report.RegisterData(employee.Value.AssignedAssets, "Assets");
        report.RegisterData(employee.Value.AssignedLicenses, "Licenses");
        
        if (report.Prepare())
        {
            var pdfExport = new PDFSimpleExport();
            pdfExport.ShowProgress = false;
            MemoryStream ms = new MemoryStream();
            report.Report.Export(pdfExport, ms);
            report.Dispose();
            pdfExport.Dispose();
            ms.Position = 0;
            return File(ms, "application/pdf", "employee.pdf");

        }
        return Ok();
    }
}
