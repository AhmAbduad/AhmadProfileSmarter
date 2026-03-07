using AhmadDAL.Models.Reportbug;
using AhmadService.dto.Credentials;
using AhmadService.dto.Reportbug;
using AhmadService.Services.Credentials;
using AhmadService.Services.ReportBug;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AhmadAPI.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ReportbugController : ControllerBase
    {
        public readonly ReportbugService reportBugService;
        public ReportbugController(ReportbugService reportBugService)
        {
            this.reportBugService = reportBugService;
        }

        [Authorize(Roles = "SuperAdmin,Admin,Moderator,User,Guest")]
        [HttpPost("SavingReportBug")]
        public async Task<bool> SavingReportBug([FromForm] ReportbugDto reportbugdto)
        {

            if (string.IsNullOrEmpty(reportbugdto.title) || string.IsNullOrEmpty(reportbugdto.description))
            {
                return false;
            }

            bool check = await reportBugService.SubmitReportbug(reportbugdto);

            return check;
        }

        [Authorize(Roles = "SuperAdmin,Admin")]
        [HttpGet("GetAllBugs")]
        public async Task<IActionResult> GetAllBugs()
        {
            var result = await reportBugService.GetAllBugs();

            if(result==null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
