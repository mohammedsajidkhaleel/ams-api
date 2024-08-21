using FastReport;
using FastReport.Export.Pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ams.api.Controllers.Reports
{
    [Authorize]
    [ApiController] 
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetEmployee()
        {
            Report report = new Report();
            report.Load("Reports\\Employee.frx");
            report.SetParameterValue("ReportTitle", "Emplyee Card");
            if (report.Prepare())
            {
                var pdfExport = new PDFExport();
                pdfExport.ShowProgress = false;
                MemoryStream ms = new MemoryStream();
                report.Report.Export(pdfExport,ms);
                report.Dispose();
                pdfExport.Dispose();
                ms.Position = 0;
                return File(ms, "application/pdf", "employee.pdf");

            }
            return Ok();
        }
    }
}
