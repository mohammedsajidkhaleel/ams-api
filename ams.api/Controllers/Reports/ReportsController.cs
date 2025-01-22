using ams.application.Reports.GetContactList;
using FastReport;
using FastReport.Export.PdfSimple;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Reports
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private ISender _sender;
        public ReportsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployee()
        {
            Report report = new Report();
            report.Load("Reports/Employee.frx");
            report.SetParameterValue("ReportTitle", "Emplyee Card");
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

        [HttpGet("contactlist")]
        [AllowAnonymous]
        public async Task<IActionResult> GetContactList()
        {
            Report report = new Report();
            report.Load("Reports/ContactList.frx");
            var query = new GetContactListQuery();
            var employees = await _sender.Send(query);
            report.RegisterData(employees.Value, "Employees");
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
            //     report.Dictionary.RegisterBusinessObject(
            //       employees.Value, // a (empty) list of objects
            //       "Employees",          // name of dataset
            //       2,                   // depth of navigation into properties
            //       true                 // enable data source
            //);
            //     report.Save(@"test1.frx");
            return Ok();
        }
    }
}
